using System.Collections.Generic;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VStockAdjDetails
    {
        public TInvtAdj StockAdj{get;set;}

        public  ICollection<TInvtAdjD> Details{get;set;}
    }
}