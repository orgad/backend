using System.Collections.Generic;
using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VRecheckDetails
    {
        public TOutCheck Recheck{get;set;}

        public ICollection<TOutCheckD> DetailList {get;set;}
    }
}