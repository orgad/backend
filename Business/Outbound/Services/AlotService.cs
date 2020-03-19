using System;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class AlotService
    {
        public TOutAlot Create(int whId,long outboundId,TInvtD[] invtDs)
        {
            var alot = new TOutAlot{
                Code = "ALT" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                WhId = whId,
                OutboundId = outboundId,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
             };

             foreach(var detail in invtDs)
             {
                 var alotDetail = new TOutAlotD{
                     Product = "",
                     SkuId = detail.SkuId,
                     InventoryId = detail.Id,
                     Barcode = detail.Barcode,
                     Carton = detail.Carton,
                     ZoneId = detail.ZoneId,
                     ZoneCode = detail.ZoneCode,
                     BinId = detail.BinId,
                     BinCode = detail.BinCode,
                     Qty = detail.Qty,
                     MatchingQty = detail.AlotQty,
                     CreatedBy = DefaultUser.UserName,
                     CreatedTime = DateTime.UtcNow
                 };

                 alot.DetailList.Add(alotDetail);
             }

             return alot;
        }
    }
}