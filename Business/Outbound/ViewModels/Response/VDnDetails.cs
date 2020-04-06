using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VDnDetails
    {
        public TOutDn Dn{get;set;}

        public TOutDnD[] DetailList{get;set;}
    }
}