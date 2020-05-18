using System.Collections.Generic;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VPickDataSource
    {
        public string Code{get;set;}

        public ICollection<SkuBinCodeQty> DetailList {get;set;}
    }
}