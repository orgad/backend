using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public partial class InventoryService
    {
        //收货
        public void Rcv(int whId, int custId, TInInboundD[] ts)
        {
            var id = ts.Select(x => x.HId).FirstOrDefault();
            var rs = new List<TInvt>();
            // 首先查询有没有库存记录,有就更新TInvt和TInvtD;

            var logs = new List<TInvtChangeLog>();

            // 没有就新增
            foreach (var t in ts)
            {
                var r = new TInvt();
                var h = wmsinventory.TInvts.Where(x => x.WhId == whId && x.SkuId == t.SkuId).FirstOrDefault();
                if (h != null)
                {
                    r = Do1(h, whId, custId, t);
                }
                else
                {
                    r = Do2(whId, custId, t);
                    rs.Add(r);
                }
            }
            wmsinventory.TInvts.AddRange(rs);

            wmsinventory.TInvtChangeLogs.AddRange(logs);

            wmsinventory.SaveChanges();
        }

        private TInvt Do1(TInvt h, int whId, int custId, TInInboundD t)
        {
            h.Qty += t.Qty;
            var bin = GetDefalutBin(whId);
            var d1 = new TInvtD
            {
                HId = h.Id,
                WhId = whId,
                SkuId = t.SkuId,
                Sku = t.Sku,
                Barcode = t.Barcode,
                ZoneId = bin.Item1,
                ZoneCode = bin.Item2,
                BinId = bin.Item3,
                BinCode = bin.Item4,
                CreatedBy = DefaultUser.UserName,
                IsDeleted = 0,
                Qty = t.Qty,
                CreatedTime = DateTime.UtcNow
            };
            var log = new TInvtChangeLog
            {
                OrderId = t.HId,
                OrderType = Enum.GetName(typeof(EnumOrderType), EnumOrderType.RCV),
                WhId = whId,
                CustId = custId,
                InvtDId = d1.Id,
                SkuId = t.SkuId,
                Barcode = t.Barcode,
                BinId = d1.BinId,
                ZoneId = d1.ZoneId,
                Qty = t.Qty,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };
            d1.TInvtChangeLog = log;
            h.DetailList.Add(d1);
            return h;
        }
        private TInvt Do2(int whId, int custId, TInInboundD t)
        {
            //这是新增的情况
            var h = new TInvt
            {
                WhId = whId,
                SkuId = t.SkuId,
                Sku = t.Sku,
                Barcode = t.Barcode,
                CreatedBy = DefaultUser.UserName,
                IsDeleted = false,
                Qty = t.Qty,
                CreatedTime = DateTime.UtcNow
            };
            var bin = GetDefalutBin(whId);
            var d2 = new TInvtD
            {
                HId = h.Id,
                WhId = whId,
                SkuId = t.SkuId,
                Sku = t.Sku,
                Barcode = t.Barcode,
                ZoneId = bin.Item1,
                ZoneCode = bin.Item2,
                BinId = bin.Item3,
                BinCode = bin.Item4,
                CreatedBy = "rick.li",
                IsDeleted = 0,
                Qty = t.Qty,
                CreatedTime = DateTime.UtcNow
            };

            var log = new TInvtChangeLog
            {
                OrderId = t.HId,
                OrderType = Enum.GetName(typeof(EnumOrderType), EnumOrderType.RCV),
                WhId = whId,
                InvtDId = d2.Id,
                CustId = custId,
                SkuId = t.SkuId,
                Barcode = t.Barcode,
                BinId = d2.BinId,
                ZoneId = d2.ZoneId,
                Qty = t.Qty,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };

            d2.TInvtChangeLog = log;
            h.DetailList.Add(d2);
            h.Qty = d2.Qty;
            return h;
        }

        public bool PutAways(int whId, TInPutawayD[] ps)
        {
            var toInvts = ps.GroupBy(x => x.SkuId);
            var bin = GetDefalutBin(whId);
            foreach (var toInvt in toInvts)
            {
                //找到收货区库存
                var invts = wmsinventory.TInvtDs.Where(x => x.SkuId == toInvt.Key && x.BinId == bin.Item3
                            && x.Qty - x.AlotQty - x.LockedQty > 0).ToList();

                //开始上架: 增加目的货位的库存，减少收货区货位的库存
                var psBysku = ps.Where(x => x.SkuId == toInvt.Key).ToArray();
                PutAway(whId, psBysku, invts);
            }
            return wmsinventory.SaveChanges() > 0;
        }
        private void PutAway(int whId, TInPutawayD[] putAwayDetailList, List<TInvtD> invts)
        {
            //单个SKU上架
            var hid = invts.Select(x => x.HId).FirstOrDefault();
            var Sku = invts.Select(x => new { x.SkuId, x.Sku, x.Barcode }).FirstOrDefault();
            //  按货位分组
            var detailByBins = putAwayDetailList.GroupBy(x => new { x.ZoneId, x.ZoneCode, x.BinId, x.BinCode });
            foreach (var detailByBin in detailByBins)
            {
                //单个SKU+货位
                //需要增加的库存
                var toZoneId = detailByBin.Key.ZoneId;
                var toZone = detailByBin.Key.ZoneCode;
                var toBinId = detailByBin.Key.BinId;
                var toBin = detailByBin.Key.BinCode;
                var qty = putAwayDetailList.Where(x => x.BinId == toBinId).Sum(x => x.Qty);

                wmsinventory.TInvtDs.Add(new TInvtD
                {
                    HId = hid,
                    WhId = whId,
                    SkuId = Sku.SkuId,
                    Sku = Sku.Sku,
                    Barcode = Sku.Barcode,
                    ZoneId = toZoneId,
                    ZoneCode = toZone,
                    BinId = toBinId,
                    BinCode = toBin,
                    Qty = qty,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow
                });

                //需要扣减的库存
                ReduceQty(qty, invts);
            }
        }

        private void ReduceQty(int totalQty, List<TInvtD> invts)
        {
            foreach (var invt in invts)
            {
                var canQty = invt.Qty - invt.AlotQty - invt.LockedQty;

                if (totalQty > 0 && canQty > 0)
                {
                    if (invt.Qty >= totalQty)
                    {
                        invt.Qty -= totalQty;
                        break;
                    }
                    else
                    {
                        totalQty -= invt.Qty;
                        invt.Qty = 0;
                    }
                }
            }
        }

        public TInvtD[] Alot(int whId, TOutD[] singleOutdetails)
        {
            var alotInvts = new List<TInvtD>();
            var groups = singleOutdetails.GroupBy(x => x.SkuId);

            //按照sku进行分组,获得分配的库存返回值
            foreach (var group in groups)
            {
                var singleSkuDetails = singleOutdetails.Where(x => x.SkuId == group.Key).ToList();
                //按单个sku进行库存分配
                var r = AlotBySku(group.Key, singleSkuDetails.ToArray());
                if (r != null && r.Any())
                    alotInvts.AddRange(r);
            }

            wmsinventory.SaveChanges();

            return alotInvts.ToArray();
        }
        private TInvtD[] AlotBySku(long skuId, TOutD[] singleSkuDetails)
        {
            var alotInvts = new List<TInvtD>();

            //找到某一个sku 的库存记录
            var o = wmsinventory.TInvts.Where(x => x.SkuId == skuId).FirstOrDefault();

            var leaveInvtQty = o.Qty - o.AlotQty - o.LockedQty;

            var totalQty = singleSkuDetails.Sum(x => x.Qty);

            if (leaveInvtQty == 0)
            {
                //没有可分配库存
                return null;
            }
            else if (leaveInvtQty >= totalQty)
            {
                //库存够分配的情况
                o.AlotQty += totalQty;
            }
            else
            {
                //库存部分分配的情况
                o.AlotQty += leaveInvtQty;
            }

            foreach (var detail in singleSkuDetails)
            {
                //返回库存明细信息
                var skuQty = detail.Qty;
                var invtDs = wmsinventory.TInvtDs.Where(x => x.SkuId == detail.SkuId && x.Qty - x.AlotQty - x.LockedQty > 0)
                            .ToList();
                if (invtDs.Any())
                {
                    if (skuQty > 0)
                    {
                        alotInvts.AddRange(AddAlotQty(skuQty, invtDs));
                    }
                }
            }

            return alotInvts.ToArray();
        }
        private List<TInvtD> AddAlotQty(int skuQty, List<TInvtD> invts)
        {
            var list = new List<TInvtD>();

            foreach (var invt in invts)
            {
                if (invt.Qty >= skuQty)
                {
                    invt.AlotQty += skuQty;
                    list.Add(invt);
                    break;
                }
                else
                {
                    invt.AlotQty = skuQty;
                    skuQty -= invt.AlotQty;
                    list.Add(invt);
                }
            }
            return list;
        }


        //扣库存
        public bool Delivery(int whId, List<TOutPickD> pickDetails)
        {
            //首先计算出要处理的SKU和货位
            var source = pickDetails.Select(x => new { x.SkuId, x.BinId }).Distinct().ToList();
            var obj = pickDetails.Select(x => new { x.SkuId, x.ActBinId }).Distinct().ToList();

            var skuBin = new List<Tuple<long, long>>();
            foreach (var item in source)
            {
                skuBin.Add(new Tuple<long, long>(item.SkuId, item.BinId));
            }

            foreach (var item in obj)
            {
                skuBin.Add(new Tuple<long, long>(item.SkuId, item.ActBinId));
            }

            skuBin = skuBin.Distinct().ToList();

            //然后去查下库存
            var skus = skuBin.GroupBy(x => x.Item1);
            var inventoryDetailList = new List<TInvtD>();
            foreach (var sku in skus)
            {
                var skuId = sku.Key;
                var binIds = skuBin.Where(x => x.Item1 == skuId).Select(x => x.Item2).ToList();
                inventoryDetailList.AddRange(wmsinventory.TInvtDs
                   .Where(x => x.WhId == whId && x.SkuId == skuId && binIds.Contains(x.BinId))
                );
            }

            //开始进行处理
            foreach (var pickDetail in pickDetails)
            {
                var detailList = inventoryDetailList.Where(x => x.SkuId == pickDetail.SkuId &&
                    x.BinId == pickDetail.BinId).ToList();
                if (pickDetail.BinId == pickDetail.ActZoneId)
                {
                    ReduceQtyAndAlotQty(1, detailList);
                }
                else
                {
                    //按推荐货位扣减锁定数
                    var detailList1 = inventoryDetailList.Where(x => x.SkuId == pickDetail.SkuId &&
                    x.BinId == pickDetail.BinId).ToList();
                    ReduceAlotQty(1, detailList1);

                    //按实际货位扣减在库数
                    var detailList2 = inventoryDetailList.Where(x => x.SkuId == pickDetail.SkuId &&
                    x.BinId == pickDetail.ActBinId).ToList();
                    ReduceQty(1, detailList2);
                }
            }

            //保存数据
            return wmsinventory.SaveChanges() > 0;
        }

        private void ReduceQtyAndAlotQty(int totalQty, List<TInvtD> invts)
        {
            foreach (var invt in invts)
            {
                if (totalQty > 0)
                {
                    if (invt.Qty >= totalQty)
                    {
                        invt.AlotQty -= totalQty;
                        invt.Qty -= totalQty;
                        break;
                    }
                    else
                    {
                        invt.Qty = 0;
                        invt.AlotQty = 0;
                        totalQty -= invt.Qty;
                    }
                }
            }
        }

        //只减少分配占用数
        private void ReduceAlotQty(int totalQty, List<TInvtD> invts)
        {
            foreach (var invt in invts)
            {
                if (totalQty > 0)
                {
                    if (invt.Qty >= totalQty)
                    {
                        invt.AlotQty -= totalQty;
                        break;
                    }
                    else
                    {
                        invt.AlotQty = 0;
                        totalQty -= invt.Qty;
                    }
                }
            }
        }
    }
}