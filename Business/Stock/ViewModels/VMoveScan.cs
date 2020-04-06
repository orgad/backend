using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VMoveScan : VScanRequest
    {
        public string TypeCode { get; set; }
        public int FromZoneId { get; set; }
        public string FromZoneCode { get; set; }
        public int FromBinId { get; set; }
        public string FromBinCode { get; set; }
        public int ToZoneId { get; set; }
        public string ToZoneCode { get; set; }
        public int ToBinId { get; set; }
        public string ToBinCode { get; set; }

    }
}