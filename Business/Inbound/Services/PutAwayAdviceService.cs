using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
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
    }
}