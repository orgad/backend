using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Outbound.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public partial class InventoryService
    {
        //扣库存
        public bool Delivery(int whId, long shpId, int custId, string shpCode, List<TOutPickD> pickDetails)
        {
            //首先计算出要处理的SKU和货位
            var source = pickDetails.Select(x => new { x.SkuId, x.BinId }).Distinct().ToList();
            var obj = pickDetails.Select(x => new { x.SkuId, x.ActBinId }).Distinct().ToList();

            var skuBin = new List<Tuple<long, int>>();
            foreach (var item in source)
            {
                skuBin.Add(new Tuple<long, int>(item.SkuId, item.BinId));
            }

            foreach (var item in obj)
            {
                skuBin.Add(new Tuple<long, int>(item.SkuId, item.ActBinId.Value));
            }

            skuBin = skuBin.Distinct().ToList();

            //然后去查下库存
            var skus = skuBin.GroupBy(x => x.Item1);
            var inventoryList = new List<TInvt>();
            var inventoryDetailList = new List<TInvtD>();
            foreach (var sku in skus)
            {
                var skuId = sku.Key;
                var binIds = skuBin.Where(x => x.Item1 == skuId).Select(x => x.Item2).ToList();

                inventoryList.AddRange(wmsinventory.TInvts
                   .Where(x => x.WhId == whId && x.SkuId == skuId && x.Qty > 0 && x.AlotQty > 0));

                inventoryDetailList.AddRange(wmsinventory.TInvtDs
                   .Where(x => x.WhId == whId && x.SkuId == skuId && binIds.Contains(x.BinId) && x.Qty > 0 && x.AlotQty > 0)
                );
            }

            //对pickDetail进行汇总处理
            //按推荐货位
            var advPicks = pickDetails.Where(x => x.BinId == x.ActBinId)
            .GroupBy(x => new { x.SkuId, x.Sku, x.BinId, x.BinCode })
            .Select(x => new SkuBinCodeQty
            {
                SkuId = x.Key.SkuId,
                Sku = x.Key.Sku,
                BinId = x.Key.BinId,
                BinCode = x.Key.BinCode,
                Qty = x.Count()
            }).ToList();

            //按实际货位
            var actPicks = pickDetails.Where(x => x.BinId != x.ActBinId).GroupBy(x => new { x.SkuId, x.Sku, x.ActBinId, x.ActBinCode })
             .Select(x => new SkuBinCodeQty
             {
                 SkuId = x.Key.SkuId,
                 Sku = x.Key.Sku,
                 BinId = x.Key.ActBinId.Value,
                 BinCode = x.Key.ActBinCode,
                 Qty = x.Count()
             }).ToList(); ;

            //开始进行处理:一条一条的扣减库存
            foreach (var pickDetail in advPicks)
            {
                var invt = inventoryList.Where(x => x.SkuId == pickDetail.SkuId).FirstOrDefault();

                var invtDetailList = inventoryDetailList.Where(x => x.SkuId == pickDetail.SkuId &&
                    x.BinId == pickDetail.BinId && x.AlotQty > 0).ToList();
                //全部按推荐货位扣减库存
                var invtds = ReduceQtyAndAlotQty(pickDetail.Qty, invt, invtDetailList);
                foreach (var r in invtds)
                {
                    this.DoDeliveryLog(shpId, shpCode, whId, custId, r, r.Qty);
                }
            }

            foreach (var pickDetail in actPicks)
            {
                var invt = inventoryList.Where(x => x.SkuId == pickDetail.SkuId).FirstOrDefault();

                var invtDetailList = inventoryDetailList.Where(x => x.SkuId == pickDetail.SkuId &&
                    x.BinId == pickDetail.BinId && x.AlotQty > 0).ToList();
                //按推荐货位扣减锁定数
                var detailList1 = inventoryDetailList.Where(x => x.SkuId == pickDetail.SkuId &&
                    x.BinId == pickDetail.BinId && x.AlotQty > 0).ToList();
                ReduceAlotQty(pickDetail.Qty, invt, detailList1);

                //按实际货位扣减在库数
                var detailList2 = inventoryDetailList.Where(x => x.SkuId == pickDetail.SkuId &&
                    x.BinId == pickDetail.BinId && x.Qty > 0).ToList();
                ReduceQty(pickDetail.Qty, invt, detailList2);
            }

            //保存数据
            return wmsinventory.SaveChanges() > 0;
        }

        private void DoDeliveryLog(long shpId, string shpCode, int whId, int custId, TInvtD invtd, int qty)
        {
            var log = new TInvtChangeLog
            {
                OrderId = shpId,
                OrderType = Enum.GetName(typeof(EnumOrderType), EnumOrderType.SHP),
                OrderCode = shpCode,
                WhId = whId,
                CustId = custId,
                InvtDId = invtd.Id,
                SkuId = invtd.SkuId,
                Barcode = invtd.Barcode,
                BinId = invtd.BinId,
                ZoneId = invtd.ZoneId,
                Qty = qty,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };
            wmsinventory.TInvtChangeLogs.Add(log);
        }

        private List<TInvtD> ReduceQtyAndAlotQty(int totalQty, TInvt invt, List<TInvtD> invtDs)
        {
            var newInvtDs = new List<TInvtD>();
            foreach (var invtd in invtDs)
            {
                var newInvtD = new TInvtD
                {
                    Id = invtd.Id,
                    HId = invtd.HId,
                    SkuId = invtd.SkuId,
                    Sku = invtd.Sku,
                    Barcode = invtd.Barcode,
                    Qty = 0,
                    AlotQty = 0,
                    ZoneId = invtd.ZoneId,
                    ZoneCode = invtd.ZoneCode,
                    BinId = invtd.BinId,
                    BinCode = invtd.BinCode,
                };

                if (totalQty > 0)
                {
                    if (totalQty <= invtd.AlotQty) //有其他出库单分配数
                    {
                        invtd.AlotQty -= totalQty;
                        invtd.Qty -= totalQty;

                        invt.AlotQty -= totalQty;
                        invt.Qty -= totalQty;

                        newInvtD.Qty = totalQty;

                        newInvtDs.Add(newInvtD);

                        break;
                    }
                    else
                    {
                        //循环扣减
                        totalQty -= invtd.AlotQty;

                        invtd.Qty -= invt.AlotQty;
                        invtd.AlotQty = 0;
                        invt.Qty -= invt.AlotQty;
                        invt.AlotQty = 0;

                        newInvtD.Qty = invtd.AlotQty;
                        newInvtDs.Add(newInvtD);
                    }
                }
            }

            return newInvtDs;
        }

        //只减少分配占用数
        private void ReduceAlotQty(int totalQty, TInvt invt, List<TInvtD> invts)
        {
            foreach (var invtd in invts)
            {
                if (totalQty > 0)
                {
                    if (invtd.Qty >= totalQty)
                    {
                        invtd.AlotQty -= totalQty;
                        break;
                    }
                    else
                    {
                        totalQty -= invtd.Qty;
                        invtd.AlotQty = 0;

                    }
                }
            }
        }

    }
}