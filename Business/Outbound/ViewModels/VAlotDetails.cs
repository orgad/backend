using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.ViewModels
{
    public class VAlotDetails
    {
        public TOutAlot Alot{get;set;}

        public TOutAlotD[] DetailList{get;set;}
    }
}