using System.Collections.Generic;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VRepPlanDetails
    {
        public TInvtReplenishPlan StockAdj{get;set;}

        public  ICollection<TInvtReplenishPlanD> Details{get;set;}
    }
}