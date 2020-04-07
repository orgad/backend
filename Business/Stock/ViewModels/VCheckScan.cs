using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VCheckScan : VScanRequest
    {
        public string ZoneCode{get;set;}
        public string BinCode{get;set;}
    }
}