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
            return this.Query(queryOut).OrderByDescending(x=>x.Id).ToList();
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
                TypeCode = "SHP",
                TransCode = "Outbound",
                SrcCode = dn.SrcCode,
                Store = store,
                IsPriority = false,
                Status = "None",
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

        public bool Alots(long[] ids)
        {
            foreach (var id in ids)
            {
                this.Alot(id);
            }
            return true;
        }
        private void Alot(long id)
        {
            // 获取出库明细
            var outbound = wmsoutbound.TOuts.Where(x => x.Id == id).FirstOrDefault();
            if (outbound == null) throw new Exception("outboud is not exist.");

            var detailList = wmsoutbound.TOutDs.Where(x => x.HId == id).ToArray();

            // 获取分配结果,更新库存记录
            var alotList = inventoryService.Alot(outbound.WhId, detailList);

            // 生成分配记录
            var r = alotService.Create(outbound.WhId, outbound.Id, detailList, alotList);
            wmsoutbound.TOutAlots.Add(r);

            //更新出库明细
            foreach (var detail in detailList)
            {
                detail.MatchingQty = alotList.Where(x => x.SkuId == detail.SkuId).Sum(X => X.AlotQty);
            }

            //更新单据状态
            outbound.AllotStatus = 2;
            outbound.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Audit);

            //保存
            wmsoutbound.SaveChanges();
        }

        public bool Picks(long[] ids)
        {
            foreach (var id in ids)
            {
                this.Pick(id);
            }
            return true;
        }

        private bool Pick(long id)
        {
            var tOut = wmsoutbound.TOuts.Where(x => x.Id == id).FirstOrDefault();
            if (tOut == null)
            {
                throw new Exception("out is null.");
            }

            var detailList = wmsoutbound.TOutDs.Where(x => x.HId == id).ToList();
            if (!detailList.Any())
            {
                throw new Exception("detail-list is null.");
            }

            tOut.DetailList = detailList;

            var result =  pickService.CreatePick(tOut);
            
            tOut.PickStatus = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Init);
            return wmsoutbound.SaveChanges()>0;
        }
    }
}