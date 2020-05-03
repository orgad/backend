using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public partial class InventoryService
    {
        //收货
        public void Rcv(int whId, int custId, string rcvCode, TInInboundD[] ts)
        {
            var id = ts.Select(x => x.HId).FirstOrDefault();
            var rs = new List<TInvt>();
            // 首先查询有没有库存记录,有就更新TInvt和TInvtD;
            // 没有就新增
            foreach (var t in ts)
            {
                var r = new TInvt();
                var h = wmsinventory.TInvts.Where(x => x.WhId == whId && x.SkuId == t.SkuId).FirstOrDefault();
                if (h != null)
                {
                    r = Do1(h, whId, custId, rcvCode, t);
                }
                else
                {
                    r = Do2(whId, custId, rcvCode, t);
                    rs.Add(r);
                }
            }
            wmsinventory.TInvts.AddRange(rs);
            wmsinventory.SaveChanges();
        }

        private TInvt Do1(TInvt h, int whId, int custId, string rcvCode, TInInboundD t)
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
                OrderCode = rcvCode,
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
        private TInvt Do2(int whId, int custId, string rcvCode, TInInboundD t)
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
                OrderCode = rcvCode,
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
     }
}