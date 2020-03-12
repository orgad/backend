using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;

namespace dotnet_wms_ef
{
    internal class QcService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();

        PutAwayService putAwayService = new PutAwayService();

        StrategyService strategyService = new StrategyService();

        ProductService productService = new ProductService();

        private IQueryable<TInQc> Query(QueryQc queryQc)
        {
            return wmsinbound.TInQcs;
        }

        public List<TInQc> PageList(QueryQc queryQc)
        {
            if (queryQc.pageSize == 0) queryQc.pageSize = 20;
            return this.Query(queryQc).
            OrderByDescending(x => x.Id).Skip(queryQc.pageIndex).Take(queryQc.pageSize).ToList();
        }

        public int TotalCount(QueryQc queryQc)
        {
            return this.Query(queryQc).Count();
        }

        public TInQc Get(long id)
        {
            var o = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();
            return o;
        }

        public VQcDetails Details(long id)
        {
            var o = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();

            var ds = wmsinbound.TInQcDs.Where(x => x.HId == id).ToList();

            return new VQcDetails { Qc = o, QcDs = ds.Any() ? ds.ToArray() : null };
        }

        public TInQc Create(TInInbound inbound)
        {
            TInQc qc = new TInQc();
            qc.Code = inbound.Code.Replace("RCV", "QC");
            qc.CreatedBy = DefaultUser.UserName;
            qc.CreatedTime = DateTime.UtcNow;
            qc.InboundId = inbound.Id;
            qc.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
            return qc;
        }

        public Tuple<bool,string> Scan(long id, TInQcD qcD)
        {
            //获取SKU的信息
            var prodSku = productService.GetSkuByBarcode(qcD.Barcode);

            var qc = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();
            
            var qty = wmsinbound.TInQcDs.Where(x=>x.HId == id && x.SkuId==prodSku.Id).Count();
            var inbound = wmsinbound.TInInbounds.Where(x => x.Id == qc.InboundId).FirstOrDefault();

            //质检扫描的时候要校验一下扫描的数量
            var totalQty = wmsinbound.TInInboundDs.Where(x => x.SkuId == prodSku.Id).Select(x => x.Qty).FirstOrDefault();
            if ( qty + 1 <= totalQty)
            {
                //新增质检扫描记录
                qcD.HId = id;
                qcD.SkuId = prodSku.Id;
                qcD.Sku = prodSku.Code;
                qcD.CreatedBy = DefaultUser.UserName;
                qcD.CreatedTime = DateTime.UtcNow;
                
                qc.Qty+=1;
                if(qc.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
                {
                    qc.FirstScanAt = DateTime.UtcNow;
                }
                qc.LastScanAt = DateTime.UtcNow;
                qc.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
                inbound.QcStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
                
                wmsinbound.TInQcDs.Add(qcD);
                var b = wmsinbound.SaveChanges()>0;
                return new Tuple<bool, string>(false,string.Format("{0}/{1}",qty+1,totalQty));
            }
            else
            {
                return new Tuple<bool, string>(true,string.Format("{0}/{1}",totalQty,totalQty));
            }         
        }

        public bool Done(long id)
        {
            var qc = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();
            qc.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Done);
            return wmsinbound.SaveChanges() > 0;
        }

        public bool Confirm(long[] ids)
        {
            foreach (var id in ids)
            {
                Confirm(id);
            }

            return true;
        }

        private bool Confirm(long id)
        {
            //更新质检单的状态和入库单的质检状态
            var qc = wmsinbound.TInQcs.Where(x => x.Id == id).FirstOrDefault();
            qc.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var inbound = wmsinbound.TInInbounds.Where(x => x.Id == qc.InboundId).FirstOrDefault();
            inbound.QcStatus = qc.Status;

            //判断是否要上架
            if (strategyService.NextFlow(inbound.WhId, inbound.CustId, inbound.BrandId,
                   EnumInOperation.Qc) == EnumInOperation.PutAway)
            {
                inbound.PStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
                wmsinbound.TInPutaways.Add(putAwayService.Create(qc));
            }

            wmsinbound.SaveChanges();

            return true;
        }
    }
}