using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VPickDetails{
        public TOutPick Pick{get;set;}

        public TOutPickD[] DetailList{get;set;}
    }
}