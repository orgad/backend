using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class InventoryService
    {
        wmsinventoryContext wmsinventory = new wmsinventoryContext();

        //收货
        public void Create(int whId, TInInboundD[] ts)
        {
            var rs = new List<TInvt>();
            // 首先查询有没有库存记录,有就更新TInvt和TInvtD;
            var detailList = new List<TInvtD>();
            // 没有就新增
            foreach (var t in ts)
            {
                var r = new TInvt();
                var h = wmsinventory.TInvts.Where(x => x.WhId == whId && x.SkuId == t.SkuId).FirstOrDefault();
                if (h != null)
                {
                    r = Do1(h, whId, t);
                }
                else
                {
                    r = Do2(whId, t);
                }
                rs.Add(r);
            }
            wmsinventory.TInvts.AddRange(rs);
            wmsinventory.SaveChanges();
        }

        private Tuple<int, string, int, string> GetDefalutBin(long whId)
        {
            WhService whService = new WhService();
            return whService.getRcvDefaultBin(whId);
        }

        private TInvt Do1(TInvt h, int whId, TInInboundD t)
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
            h.DetailList.Add(d1);
            return h;
        }

        private TInvt Do2(int whId, TInInboundD t)
        {
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
            h.DetailList.Add(d2);
            h.Qty += d2.Qty;

            return h;
        }

        public bool PutAways(int whId, TInPutawayD[] ps)
        {
            var toInvts = ps.GroupBy(x => x.SkuId);
            var bin = GetDefalutBin(whId);
            foreach (var toInvt in toInvts)
            {
                //找到收货区库存
                var invts = wmsinventory.TInvtDs.Where(x => x.SkuId == toInvt.Key && x.BinId == bin.Item3)
                .ToList();

                //开始上架: 增加目的货位的库存，减少收货区货位的库存
                var psBysku = ps.Where(x => x.SkuId == toInvt.Key).ToArray();
                PutAway(psBysku, invts);
            }
            return wmsinventory.SaveChanges()>0;
        }

        private void PutAway(TInPutawayD[] putAwayDetailList, List<TInvtD> invts)
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
                    SkuId = Sku.SkuId,
                    Sku = Sku.Sku,
                    Barcode = Sku.Barcode,
                    Qty = qty,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow
                });

                //需要扣减的库存
                Reduce(qty,invts);
            }
        }

        private void Reduce(int totalQty, List<TInvtD> invts)
        {
            foreach (var invt in invts)
            {
                if (totalQty > 0)
                {
                    if (invt.Qty >= totalQty)
                    {
                        invt.Qty -= totalQty;
                        break;
                    }
                    else
                    {
                        invt.Qty = 0;
                        totalQty -= invt.Qty;
                    }
                }
            }
        }
    }
}