using System.Collections.Generic;
using dotnet_wms_ef.Auth.Models;

namespace dotnet_wms_ef.Auth.ViewModels
{
    public class VNavActionDetails
    {
        public TPermNav Nav { get; set; }
        public ICollection<TPermNavAction> DetailList { get; set; }
    }
}