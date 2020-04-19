using System.Collections.Generic;
using dotnet_wms_ef.Inbound.Models;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VRnDetails
    {
        public TInRn Rn{get;set;}
        public ICollection<TInRnD> DetailList{get;set;}
    }
}