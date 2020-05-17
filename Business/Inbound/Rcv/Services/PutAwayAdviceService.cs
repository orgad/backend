using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.Inbound.ViewModels;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Inbound.Services
{
    public class PutAwayAdviceService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();
        public List<TInPutawayAdvice> PageList()
        {
            return this.Query().
            OrderByDescending(x => x.Id).ToList();
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        private IQueryable<TInPutawayAdvice> Query()
        {
            var query = wmsinbound.TInPutawayAdvice as IQueryable<TInPutawayAdvice>;

            /*
            if (queryInbound.SkuId > 0)
            {
                query = query.Where(x => x.SkuId == queryInbound.SkuId);
            }
            if (!string.IsNullOrEmpty(queryInbound.Barcode))
            {
                query = query.Where(x => x.Barcode == queryInbound.Barcode);
            }
            */

            return query;
        }

        public VPutAwayPrintSource PrintList(long inboundId)
        {
            var o = new VPutAwayPrintSource();
            var list = new List<SkuBinCodeQty>();
            var query = wmsinbound.TInPutawayAdvice.Where(x => x.InboundId == inboundId);
            list = query.GroupBy(x => new { x.SkuId, x.Barcode, x.BinCode })
                   .Select(y => new SkuBinCodeQty
                   {
                       SkuId = y.Key.SkuId,
                       Sku = y.Key.Barcode,
                       BinCode = y.Key.BinCode,
                       Qty = y.Sum(x => x.Qty)
                   }).ToList();
            o.Code = wmsinbound.TInPutaways.Where(x => x.InboundId == inboundId).Select(x => x.Code).FirstOrDefault();
            o.details = list;
            return o;
        }
    }
}