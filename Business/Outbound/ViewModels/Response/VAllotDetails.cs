using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VAllotDetails
    {
        public TOutAllot Allot{get;set;}

        public TOutAllotD[] DetailList{get;set;}
    }
}