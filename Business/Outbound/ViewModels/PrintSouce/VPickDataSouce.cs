using System.Collections.Generic;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VPickDataSource
    {
        public string Code{get;set;}

        public ICollection<VPickDetail> DetailList {get;set;}
    }
}