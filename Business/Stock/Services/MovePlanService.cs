using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Product.Services;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.Services
{
    public class MovePlanService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();

        public List<TInvtMovePlan> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        private IQueryable<TInvtMovePlan> Query()
        {
            return wmsstock.TInvtMovePlans.OrderByDescending(x => x.Id)
            as IQueryable<TInvtMovePlan>;
        }
    }
}