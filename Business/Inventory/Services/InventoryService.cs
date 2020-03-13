using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class InventoryService
    {
        wmsinventoryContext wmsinventory = new wmsinventoryContext();

        //收货
        public void Create(int whId, int custId, TInInboundD[] ts)
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

        private Tuple<int, string, int, string> GetDefalutBin(long whId)
        {
            WhService whService = new WhService();
            return whService.getRcvDefaultBin(whId);
        }

        public List<TInvt> PageList(QueryInvt queryInvt)
        {
            if (queryInvt.PageSize == 0) queryInvt.PageSize = 20;
            return this.Query(queryInvt).
            OrderByDescending(x => x.Id).Skip(queryInvt.PageIndex).Take(queryInvt.PageSize).ToList();
        }

        public int TotalCount(QueryInvt queryInvt)
        {
            return this.Query(queryInvt).Count();
        }

        private IQueryable<TInvt> Query(QueryInvt queryInvt)
        {
            if (queryInvt.PageSize == 0)
            {
                queryInvt.PageSize = 20;
            }
            var query = wmsinventory.TInvts as IQueryable<TInvt>;
            if (queryInvt.SkuId > 0)
            {
                query = query.Where(x => x.SkuId == queryInvt.SkuId);
            }
            if (!string.IsNullOrEmpty(queryInvt.Barcode))
            {
                query = query.Where(x => x.Barcode == queryInvt.Barcode);
            }
            return query;
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
                var invts = wmsinventory.TInvtDs.Where(x => x.SkuId == toInvt.Key && x.BinId == bin.Item3)
                .ToList();

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
                Reduce(qty, invts);
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