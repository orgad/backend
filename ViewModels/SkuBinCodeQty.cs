namespace dotnet_wms_ef.ViewModels
{
    public class SkuBinCodeQty
    {
        public long Id { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public int BinId { get; set; }
        public string BinCode { get; set; }
        public int Qty { get; set; }
    }
}