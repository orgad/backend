using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.Inbound.ViewModels;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;

namespace dotnet_wms_ef.Inbound.Services
{
    public class InboundService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();

        wmsinventoryContext wmsinventory = new wmsinventoryContext();

        QcService qcService = new QcService();

        PutAwayService putAwayService = new PutAwayService();

        InventoryService inventoryService = new InventoryService();

        StrategyService strategyService = new StrategyService();

        //创建入库单
        public TInInbound CreateByAsn(TInAsn asn)
        {
            TInInbound r = new TInInbound();
            r.Code = asn.Code.Replace(Enum.GetName(typeof(EnumOrderType), EnumOrderType.ASN),
                                      Enum.GetName(typeof(EnumOrderType), EnumOrderType.RCV));
            r.AsnId = asn.Id;
            r.AsnCode = asn.Code;
            r.BatchNo = asn.BatchNo;
            r.BizCode = asn.BizCode;
            r.WhId = asn.WhId;
            r.CustId = asn.CustId;
            r.BrandId = asn.BrandId;
            r.GoodsType = asn.GoodsType;
            r.SrcCode = asn.SrcCode;
            r.TransCode = asn.TransCode;
            r.TypeCode = Enum.GetName(typeof(EnumOrderType), EnumOrderType.RCV);
            r.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.None);
            r.RStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
            r.CreatedBy = DefaultUser.UserName;
            r.CreatedTime = DateTime.UtcNow;
            return r;
        }

        public bool Create(VInboundAddForm vInbound)
        {
            TInInbound inbound = new TInInbound
            {
                WhId = vInbound.WhId,
                CustId = vInbound.CustId,
                BrandId = vInbound.BrandId,
                BatchNo = DateTime.Now.ToString("yyyyMMdd"),
                Code = "RCV" + DateTime.Now.ToString(FormatString.DefaultFormat),
                BizCode = vInbound.BizCode,
                GoodsType = vInbound.GoodsType,
                SrcCode = "Import",
                TransCode = "Inbound",
                TypeCode = "RCV",
                Status = Enum.GetName(typeof(EnumStatus),EnumStatus.None),
                RStatus = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Init),
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };
            wmsinbound.TInInbounds.Add(inbound);

            return wmsinbound.SaveChanges() > 0;
        }

        public string CreateByPreQc(string transCode, TInPreQc[] qcs)
        {
            var qc = qcs.FirstOrDefault();
            TInInbound inbound = new TInInbound
            {
                WhId = qc.WhId,
                CustId = qc.CustId,
                BrandId = qc.BrandId,
                BatchNo = DateTime.Now.ToString("yyyyMMdd"),
                Code = "RCV" + DateTime.Now.ToString(FormatString.DefaultFormat),
                BizCode = "ECom",
                GoodsType = "Prod",
                SrcCode = qc.SrcCode,
                TransCode = transCode,
                TypeCode = "RCV",
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };
            wmsinbound.TInInbounds.Add(inbound);
            wmsinbound.SaveChanges();
            return inbound.Code;
        }

        //分页查询
        public List<TInInbound> PageList(QueryInbound query)
        {
            return this.Query(query).OrderByDescending(x => x.Id).ToList();
        }

        private IQueryable<TInInbound> Query(QueryInbound query)
        {
            var q = wmsinbound.TInInbounds as IQueryable<TInInbound>;
            q = q.Where(x => x.TransCode == query.TransCode);
            return q;
        }

        public int TotalCount(QueryInbound query)
        {
            return this.Query(query).Count();
        }

        public VInboundDetails Details(long id)
        {
            var o = wmsinbound.TInInbounds.Where(x => x.Id == id).FirstOrDefault();

            var ds = wmsinbound.TInInboundDs.Where(x => x.HId == id).ToList();

            return new VInboundDetails { Inbound = o, InboundDs = ds.Any() ? ds.ToArray() : null };
        }

        public TInInbound GetByAsn(long asnId)
        {
            var o = wmsinbound.TInInbounds.Where(x => x.AsnId == asnId).FirstOrDefault();

            return o;
        }

        public List<TInInboundRcv> RcvList()
        {
            return wmsinbound.TInInboundRcvs.ToList();
        }

        public int RcvTotal()
        {
            return wmsinbound.TInInboundRcvs.Count();
        }

        /*收货扫描记录*/


        //收货确认,生成库存
        public List<Tuple<bool, long, string>> RcvAffirm(long[] ids)
        {
            var list = new List<Tuple<bool, long, string>>();
            var inbounds = wmsinbound.TInInbounds.Where(x => ids.Contains(x.Id)).ToList();
            var inboundDs = wmsinbound.TInInboundDs.Where(x => ids.Contains(x.HId)).ToList();
            foreach (var inbound in inbounds)
            {
                if (inbound.Status != Enum.GetName(typeof(EnumStatus), EnumStatus.None))
                {
                    //表示已经确认过了
                    list.Add(new Tuple<bool, long, string>(false, inbound.Id, inbound.Code));
                    continue;
                }
                if (inbound.RStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
                {
                    //表示还没做收货扫描
                    list.Add(new Tuple<bool, long, string>(false, inbound.Id, inbound.Code));
                    continue;
                }

                var detailList = inboundDs.Where(x => x.HId == inbound.Id).ToArray();

                //生成库存记录
                inventoryService.Rcv(inbound.WhId, inbound.CustId, inbound.Code, detailList);

                inbound.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Audit);

                //修改单据状态
                inbound.RStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

                //调用策略
                if (strategyService.NextFlow(inbound.WhId, inbound.CustId, inbound.BrandId,
                    EnumInOperation.Receiving) == EnumInOperation.Qc)
                {
                    inbound.QcStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
                    wmsinbound.TInQcs.Add(qcService.Create(inbound));
                }
                else if (strategyService.NextFlow(inbound.WhId, inbound.CustId, inbound.BrandId,
                    EnumInOperation.Receiving) == EnumInOperation.PutAway)
                {
                    inbound.PStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
                    wmsinbound.TInPutaways.Add(putAwayService.Create(inbound));
                }
                else
                {
                    inbound.PStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
                    inbound.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Finished);
                    inbound.IsConfirm = true;
                    inbound.ActualInAt = DateTime.UtcNow;
                }

                var r1 = wmsinbound.SaveChanges() > 0;

                var r = new Tuple<bool, long, string>(r1, inbound.Id, "");
                list.Add(r);
            }
            return list;
        }

        //质检完成
        public List<Tuple<long, bool>> QcAffirm(long[] ids)
        {
            var list = new List<Tuple<long, bool>>();
            var inbounds = wmsinbound.TInInbounds.Where(x => ids.Contains(x.Id)).ToList();
            var qcs = wmsinbound.TInQcs.Where(x => ids.Contains(x.InboundId)).ToList();
            foreach (var inbound in inbounds)
            {
                //修改单据状态
                inbound.QcStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
                var qc = qcs.Where(x => x.InboundId == inbound.Id).FirstOrDefault();
                qc.Status = inbound.QcStatus;

                if (strategyService.NextFlow(inbound.WhId, inbound.CustId, inbound.BrandId,
                    EnumInOperation.Qc) == EnumInOperation.PutAway)
                {
                    inbound.PStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
                    wmsinbound.TInPutaways.Add(putAwayService.Create(inbound));
                }

                var r1 = wmsinbound.SaveChanges() > 0;

                var r = new Tuple<long, bool>(inbound.Id, r1);
                list.Add(r);
            }

            return list;
        }

        //上架
        public List<Tuple<long, bool>> PtAffirm(long[] ids)
        {
            var list = new List<Tuple<long, bool>>();
            foreach (var id in ids)
            {
                var r = Confirm(id);
                list.Add(new Tuple<long, bool>(id, r.Item1));
            }
            return list;
        }

        public Tuple<bool, long, string> Confirm(long id)
        {
            var pt = wmsinbound.TInPutaways.Where(x => x.InboundId == id).FirstOrDefault();

            return putAwayService.Confirm(pt.Id);
        }
    }
}