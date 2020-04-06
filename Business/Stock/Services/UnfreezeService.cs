using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.Services
{
    public class UnfreezeService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();

        public List<TInvtUnfreeze> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        private IQueryable<TInvtUnfreeze> Query()
        {
            return wmsstock.TInvtUnfreezes.OrderByDescending(x => x.Id)
            as IQueryable<TInvtUnfreeze>;
        }
    }
}