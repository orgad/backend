using System.Collections.Generic;
using dotnet_wms_ef.Auth.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Auth.ViewModels
{
    public class VNavActionDetails
    {
        public TPermNav Nav { get; set; }
        public ICollection<TPermNavAction> DetailList { get; set; }
    }
}