using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Outbound.Models;
using dotnet_wms_ef.Outbound.ViewModels;

namespace dotnet_wms_ef.Outbound.Services
{
    public class DnDetailService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        public List<TOutDnD> PageList(QueryDn queryDn, long id)
        {
            return this.Query(queryDn,id).ToList();
        }

        public int TotalCount(QueryDn queryDn,long id)
        {
            return this.Query(queryDn,id).Count();
        }

        private IQueryable<TOutDnD> Query(QueryDn queryDn,long id)
        {
            var query = wmsoutbound.TOutDnDs;
            return query;
        }
    }
}