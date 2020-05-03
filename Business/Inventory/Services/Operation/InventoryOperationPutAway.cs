using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Outbound.Models;
using dotnet_wms_ef.Outbound.ViewModels;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public partial class InventoryService
    {
        public bool PutAways(int whId, int custId, long ptaId, string ptaCode, TInPutawayD[] ps)
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
                PutAway(whId, custId, ptaId, ptaCode, psBysku, invts);
            }
            return wmsinventory.SaveChanges() > 0;
        }
        private void PutAway(int whId, int custId, long ptaId, string ptaCode, TInPutawayD[] putAwayDetailList, List<TInvtD> invts)
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

                var d2 = new TInvtD
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
                };

                d2.TInvtChangeLog = new TInvtChangeLog
                {
                    OrderId = ptaId,
                    OrderType = Enum.GetName(typeof(EnumOrderType), EnumOrderType.PTA),
                    OrderCode = ptaCode,
                    WhId = whId,
                    InvtDId = d2.Id,
                    CustId = custId,
                    SkuId = Sku.SkuId,
                    Barcode = Sku.Barcode,
                    BinId = d2.BinId,
                    ZoneId = d2.ZoneId,
                    Qty = qty,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow,
                };

                wmsinventory.TInvtDs.Add(d2);

                //需要扣减的库存
                ReduceQty(qty, null, invts);
            }
        }
    }
}