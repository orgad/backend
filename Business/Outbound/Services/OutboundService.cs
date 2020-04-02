using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class OutboundService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        InventoryService inventoryService = new InventoryService();

        AlotService alotService = new AlotService();

        PickService pickService = new PickService();

        SkuService skuService = new SkuService();
        public List<TOut> PageList(QueryOut queryOut)
        {
            return this.Query(queryOut).OrderByDescending(x => x.Id).ToList();
        }

        public int TotalCount(QueryOut queryOut)
        {
            return this.Query(queryOut).Count();
        }

        private IQueryable<TOut> Query(QueryOut queryOut)
        {
            var query = wmsoutbound.TOuts;
            return query;
        }

        public VOutboundDetails Details(long outId)
        {
            var outbound = wmsoutbound.TOuts.Where(x => x.Id == outId).FirstOrDefault();
            var detailList = wmsoutbound.TOutDs.Where(x => x.HId == outId).ToArray();

            return new VOutboundDetails { Outbound = outbound, DetailList = detailList };
        }

        public List<Tuple<bool, string>> CreateOutFromDn(TOutDn dn)
        {
            var results = new List<Tuple<bool, string>>();
            var outbound = wmsoutbound.TOuts.Where(x => x.DnId == dn.Id).FirstOrDefault();
            if (outbound != null)
                results.Add(new Tuple<bool, string>(false, dn.Code + "is exist"));

            dn.DetailList = wmsoutbound.TOutDnDs.Where(x => x.HId == dn.Id).ToList();

            var shops = dn.DetailList.Select(x => x.Store).ToList();
            if (shops != null && shops.Any())
            {
                var groups = dn.DetailList.GroupBy(x => x.Store);
                foreach (var group in groups)
                {
                    var detailList = dn.DetailList.Where(x => x.Store == group.Key).ToList();
                    results.Add(CreateOutbound(dn, group.Key, detailList));
                }
            }
            else
            {
                results.Add(CreateOutbound(dn, "", dn.DetailList.ToList()));
            }

            return results;
        }

        private Tuple<bool, string> CreateOutbound(TOutDn dn, string store, List<TOutDnD> list)
        {
            var outbound = new TOut
            {
                Code = dn.Code.Replace("DN", "SHP"),
                BatchNo = dn.BatchNo,
                AsnId = dn.AsnId,
                WhId = dn.WhId,
                CustId = dn.CustId,
                BrandId = dn.BrandId,
                DnId = dn.Id,
                DnCode = dn.Code,
                BizCode = dn.BizCode,
                GoodsType = dn.GoodsType,
                TypeCode = Enum.GetName(typeof(EnumOrderType), EnumOrderType.SHP),
                TransCode = "Outbound",
                SrcCode = dn.SrcCode,
                Store = store,
                IsPriority = false,
                Status = Enum.GetName(typeof(EnumStatus), EnumStatus.None),
                IsDeleted = false,
                OrderPayment = dn.OrderPayment,
                Payment = dn.Payment,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow
            };


            var detailList = new List<TOutD>();
            foreach (TOutDnD detail in list)
            {
                var prodSku = skuService.GetSkuByBarcode(detail.Barcode);

                detailList.Add(new TOutD
                {
                    Qty = detail.Qty,
                    Carton = detail.Carton,
                    Barcode = detail.Barcode,
                    Sku = detail.Sku,
                    SkuId = prodSku.Id,
                    RetailPrice = detail.RetailPrice,
                    ActualPrice = detail.ActualPrice,
                    Discount = detail.Discount,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow
                });
            }

            outbound.DetailList = detailList;

            wmsoutbound.TOuts.Add(outbound);

            var r = wmsoutbound.SaveChanges() > 0;

            return new Tuple<bool, string>(r, "");
        }

        public List<Tuple<bool, long, string>> Alots(long[] ids)
        {
            var list = new List<Tuple<bool, long, string>>();
            var outbounds = wmsoutbound.TOuts.Where(x => !x.IsCancel && x.AllotStatus < 2 && ids.Contains(x.Id));
            //首先清理不需要处理的单据
            foreach (var id in ids)
            {
                if (!outbounds.Any(x => x.Id == id))
                {
                    list.Add(new Tuple<bool, long, string>(false, id, ""));
                }
            }

            //处理剩余的
            foreach (var outbound in outbounds)
            {
                // 获取出库明细
                if (outbound == null) throw new Exception("outboud is not exist.");
                list.Add(this.Alot(outbound));
            }
            return list;
        }
        private Tuple<bool, long, string> Alot(TOut outbound)
        {
            var detailList = wmsoutbound.TOutDs.Where(x => x.HId == outbound.Id).ToArray();

            // 获取分配结果,更新库存记录
            // 支持二次分配, 剩余未分配数 = 期望出库数 - 已分配数
            var alotList = inventoryService.Alot(outbound.WhId, detailList);

            // 生成分配记录
            var r = alotService.Create(outbound.WhId, outbound.Id, detailList, alotList);
            wmsoutbound.TOutAlots.Add(r);

            //更新出库明细
            //支持二次分配,分配数量进行累加
            foreach (var detail in detailList)
            {
                detail.MatchingQty += alotList.Where(x => x.SkuId == detail.SkuId).Sum(X => X.AlotQty);
            }

            //更新单据状态
            var allMatchingQty = detailList.Sum(x => x.MatchingQty);
            var allQty = detailList.Sum(x => x.Qty);
            if (allMatchingQty == 0)
            {
                outbound.AllotStatus = -1;
            }
            else if (allQty > allMatchingQty)
            {
                outbound.AllotStatus = 1;
            }
            else
            {
                outbound.AllotStatus = 2;
            }

            outbound.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Audit);

            //保存
            var r1 = wmsoutbound.SaveChanges() > 0;
            return new Tuple<bool, long, string>(r1, outbound.Id, "");
        }

        public List<Tuple<bool, long, string>> Picks(long[] ids)
        {
            var list = new List<Tuple<bool, long, string>>();
            //首先排除掉已经做过拣货的
            var outs = wmsoutbound.TOuts
                      .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.None)
                                   || string.IsNullOrEmpty(x.Status)
                                   && ids.Contains(x.Id))
                      .ToList();
            //不能重复处理的直接返回false
            foreach (var id in ids)
            {
                if (!outs.Any(x => x.Id == id))
                    list.Add(new Tuple<bool, long, string>(false, id, ""));
            }
            //可以继续操作的
            foreach (var outboud in outs)
            {
                list.Add(this.Pick(outboud));
            }
            return list;
        }

        private Tuple<bool, long, string> Pick(TOut outbound)
        {
            var detailList = wmsoutbound.TOutDs.Where(x => x.HId == outbound.Id).ToList();
            if (!detailList.Any())
            {
                throw new Exception("detail-list is null.");
            }

            outbound.DetailList = detailList;

            var result = pickService.CreatePick(outbound);

            outbound.PickStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
            var r1 = wmsoutbound.SaveChanges() > 0;

            return new Tuple<bool, long, string>(r1, outbound.Id, "");
        }
    }
}