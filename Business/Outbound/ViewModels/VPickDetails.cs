using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Controllers
{
    public class VPickDetails{
        public TOutPick Pick{get;set;}

        public TOutPickD[] DetailList{get;set;}
    }
}