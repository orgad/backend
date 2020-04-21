using System.Collections.Generic;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VFreezeDetails
    {
        public TInvtFreeze Freeze { get; set; }

        public ICollection<TInvtFreezeLimits> FreezeLimits { get; set; }

        public ICollection<TInvtFreezeD> DetailList { get; set; }
    }
}