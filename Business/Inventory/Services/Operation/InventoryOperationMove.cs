
using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public partial class InventoryService
    {
        public void Locked(VInvtData vData)
        {
            //首先查询库存,然后循环扣减
            var invts = wmsinventory.TInvtDs.Where(x => x.ZoneId == vData.ZoneId && x.BinId == vData.BinId
                && x.SkuId == vData.SkuId && x.Qty - x.AlotQty - x.LockedQty > 0).ToList();

            var totalQty = vData.Qty;
            foreach (var invt in invts)
            {
                if (totalQty > 0)
                {
                    var canQty = invt.Qty - invt.AlotQty - invt.LockedQty;
                    if (canQty >= totalQty)
                    {
                        invt.LockedQty += totalQty;
                        totalQty = 0;
                    }
                    else
                    {
                        invt.LockedQty += canQty;
                        totalQty -= canQty;
                    }
                }
            }

            wmsinventory.SaveChanges();
        }

        public void UnlockAndMove(long oId, string oCode, int oWhId, int oCustId,
            VInvtData fromData, VInvtData toData)
        {
            //首先查询库存,然后循环扣减
            var invts = wmsinventory.TInvtDs
                .Where(x => x.ZoneId == fromData.ZoneId && x.BinId == fromData.BinId
                && x.SkuId == fromData.SkuId && x.Qty - x.AlotQty - x.LockedQty > 0 && x.LockedQty > 0)
                .ToList();

            var totalQty = fromData.Qty;
            var detaiList = new List<TInvtD>();

            foreach (var invt in invts)
            {
                var invtDetail = new TInvtD
                {
                    HId = invt.HId,
                    ZoneId = toData.ZoneId,
                    ZoneCode = toData.ZoneCode,
                    BinId = toData.BinId,
                    BinCode = toData.BinCode,
                    SkuId = toData.SkuId,
                    Sku = toData.Sku,
                    Barcode = toData.Barcode,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow
                };

                var invtLog = new TInvtChangeLog
                {
                    OrderId = oId,
                    OrderType = Enum.GetName(typeof(EnumOrderType), EnumOrderType.RCV),
                    OrderCode = oCode,
                    WhId = oWhId,
                    InvtDId = invtDetail.Id,
                    CustId = oCustId,
                    SkuId = toData.SkuId,
                    Barcode = toData.Barcode,
                    BinId = toData.BinId,
                    ZoneId = toData.ZoneId,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow,
                };

                var invtLog2 = new TInvtChangeLog
                {
                    OrderId = oId,
                    OrderType = Enum.GetName(typeof(EnumOrderType), EnumOrderType.RCV),
                    OrderCode = oCode,
                    WhId = oWhId,
                    InvtDId = invt.Id,
                    CustId = oCustId,
                    SkuId = toData.SkuId,
                    Barcode = toData.Barcode,
                    BinId = toData.BinId,
                    ZoneId = toData.ZoneId,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow,
                };

                if (totalQty > 0)
                {
                    var canQty = invt.LockedQty;
                    if (canQty >= totalQty)
                    {
                        invt.LockedQty -= totalQty;
                        totalQty = 0;

                        invtLog2.Qty = totalQty;
                        invt.TInvtChangeLog = invtLog2;

                        invtDetail.Qty = totalQty;
                        invtLog.Qty = totalQty;
                        invtDetail.TInvtChangeLog = invtLog;
                        detaiList.Add(invtDetail);
                    }
                    else
                    {
                        invt.LockedQty -= canQty;
                        totalQty -= canQty;

                        invtLog2.Qty = canQty;
                        invt.TInvtChangeLog = invtLog2;

                        invtDetail.Qty = canQty;
                        invtLog.Qty = canQty;

                        invtDetail.TInvtChangeLog = invtLog;
                        detaiList.Add(invtDetail);
                    }
                }
            }

            wmsinventory.TInvtDs.AddRange(detaiList);

            wmsinventory.SaveChanges();
        }
    }
}