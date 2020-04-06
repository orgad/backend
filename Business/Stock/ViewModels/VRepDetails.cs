using System.Collections.Generic;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VRepDetails
    {
        public TInvtReplenish StockAdj{get;set;}

        public  ICollection<TInvtReplenishD> Details{get;set;}
    }
}