namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VPreQcDetail
    {
        public long NoticeId { get; set; }
        public string NoticeCode { get; set; }
        public long NoticeDId { get; set; }
        public string Carton { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public string QcCode { get; set; }
    }
}