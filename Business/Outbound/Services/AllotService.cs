using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Outbound.Models;
using dotnet_wms_ef.Outbound.ViewModels;

namespace dotnet_wms_ef.Outbound.Services
{
    public class AllotService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        public void UseTransaction(IDbContextTransaction transaction)
        {
            wmsoutbound.Database.UseTransaction(transaction.GetDbTransaction());
        }

        public TOutAllot Create(int whId, long outboundId, string outboundCode, TOutD[] outds, TInvtD[] allots)
        {
            var allot = new TOutAllot
            {
                Code = "ALT" + DateTime.Now.ToString(FormatString.DefaultFormat),
                WhId = whId,
                OutboundId = outboundId,
                OutboundCode = outboundCode,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };

            foreach (var detail in allots)
            {
                var allotDetail = new TOutAllotD
                {
                    Product = "",
                    SkuId = detail.SkuId,
                    InvtDId = detail.Id,
                    Barcode = detail.Barcode,
                    Carton = detail.Carton,
                    ZoneId = detail.ZoneId,
                    ZoneCode = detail.ZoneCode,
                    BinId = detail.BinId,
                    BinCode = detail.BinCode,
                    Qty = detail.Qty,
                    MatchingQty = detail.AllotQty,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow
                };

                allot.DetailList.Add(allotDetail);
            }

            return allot;
        }

        public List<TOutAllot> PageList()
        {
            return this.Query().OrderByDescending(x => x.Id).ToList();
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        private IQueryable<TOutAllot> Query()
        {
            var query = wmsoutbound.TOutAllots;
            return query;
        }

        public VAllotDetails Details(long id)
        {
            var o = wmsoutbound.TOutAllots.Where(x => x.Id == id).FirstOrDefault();
            var detailList = wmsoutbound.TOutAllotDs.Where(x => x.HId == id).ToArray();

            return new VAllotDetails { Allot = o, DetailList = detailList };
        }

    }
}