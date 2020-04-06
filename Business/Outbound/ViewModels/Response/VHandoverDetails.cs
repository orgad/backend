using System.Collections.Generic;
using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VHandoverDetails
    {
        public TOutHandover Handover{get;set;}

        public ICollection<TOutHandoverD> DetailList {get;set;}
    }
}