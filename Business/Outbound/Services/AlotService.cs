using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace dotnet_wms_ef.Services
{
    public class AlotService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        public void UseTransaction(IDbContextTransaction transaction)
        {
            wmsoutbound.Database.UseTransaction(transaction.GetDbTransaction());
        }

        public TOutAlot Create(int whId, long outboundId, TInvtD[] invtDs)
        {
            var alot = new TOutAlot
            {
                Code = "ALT" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                WhId = whId,
                OutboundId = outboundId,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };

            foreach (var detail in invtDs)
            {
                var alotDetail = new TOutAlotD
                {
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

        public List<TOutAlot> PageList()
        {
            return this.Query().ToList();
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        private IQueryable<TOutAlot> Query()
        {
            var query = wmsoutbound.TOutAlots;
            return query;
        }

        public VAlotDetails Details(long id)
        {
            var o = wmsoutbound.TOutAlots.Where(x => x.Id == id).FirstOrDefault();
            var detailList = wmsoutbound.TOutAlotDs.Where(x => x.HId == id).ToArray();

            return new VAlotDetails { Alot = o, DetailList = detailList };
        }

    }
}