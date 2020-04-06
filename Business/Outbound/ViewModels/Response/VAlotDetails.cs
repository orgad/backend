using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VAlotDetails
    {
        public TOutAlot Alot{get;set;}

        public TOutAlotD[] DetailList{get;set;}
    }
}