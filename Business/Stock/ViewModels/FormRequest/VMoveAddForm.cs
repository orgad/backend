namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VMoveAddForm
    {
        public int WhId { get; set; }
        public string TypeCode { get; set; }
        public int FromZoneId { get; set; }
        public string FromZoneCode { get; set; }
        public int FromBinId { get; set; }
        public string FromBinCode { get; set; }
        public int ToZoneId { get; set; }
        public string ToZoneCode { get; set; }
        public int ToBinId { get; set; }
        public string ToBinCode { get; set; }
        public string Carton { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }

    }
}