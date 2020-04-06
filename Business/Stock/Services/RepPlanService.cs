using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.Services
{
    public class RepPlanService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();

        public List<TInvtReplenishPlan> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        private IQueryable<TInvtReplenishPlan> Query()
        {
            return wmsstock.TInvtReplenishPlans.OrderByDescending(x => x.Id)
            as IQueryable<TInvtReplenishPlan>;
        }
    }
}