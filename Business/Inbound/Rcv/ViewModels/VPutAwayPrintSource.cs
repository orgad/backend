using System.Collections.Generic;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VPutAwayPrintSource
    {
        public string Code{get;set;}

        public ICollection<SkuBinCodeQty> details{get;set;}
    }
}