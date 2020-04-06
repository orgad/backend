using System.Collections.Generic;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VFreezeDetails
    {
        public TInvtFreeze StockFreeze { get; set; }

        public ICollection<TInvtFreezeLimits> Limits { get; set; }

        public ICollection<TInvtFreezeD> Details { get; set; }
    }
}