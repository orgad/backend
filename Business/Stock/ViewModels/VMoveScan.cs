using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VMoveScan : VScanRequest
    {
        public string ToBinCode { get; set; }
    }
}