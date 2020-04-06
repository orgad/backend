using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VScanBinRequest : VScanRequest
    {
        public string AdvBinCode { get; set; }
        public string BinCode { get; set; }
    }
}