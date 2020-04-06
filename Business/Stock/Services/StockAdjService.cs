using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.ViewModels;

namespace dotnet_wms_ef.Stock.Services
{
    public class StockAdjService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();

        public List<TInvtAdj> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        private IQueryable<TInvtAdj> Query()
        {
            return wmsstock.TInvtAdjs.OrderByDescending(x => x.Id)
            as IQueryable<TInvtAdj>;
        }

        public VStockAdjDetails Details(long id)
        {
            var o = wmsstock.TInvtAdjs.Where(x=>x.Id==id).FirstOrDefault();
            var detailList = wmsstock.TInvtAdjDs.Where(x=>x.HId == id).ToList();
           return new VStockAdjDetails{
               StockAdj = o,
               Details = detailList
           };
        }
    }
}