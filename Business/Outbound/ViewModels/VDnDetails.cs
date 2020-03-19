using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.ViewModels
{
    public class VDnDetails
    {
        public TOutDn Dn{get;set;}

        public TOutDnD[] DetailList{get;set;}
    }
}