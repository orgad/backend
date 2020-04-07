using System.Collections.Generic;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VStockCheckDetails
    {
        public TInvtCheck StockCheck { get; set; }

        public ICollection<TInvtCheckLimits> CheckLimits { get; set; }

        public ICollection<TInvtCheckD> DetailList { get; set; }
    }
}