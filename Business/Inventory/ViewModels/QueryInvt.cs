namespace dotnet_wms_ef.ViewModels
{
    public class QueryInvt : PagedParams
    {
        public long SkuId{get;set;}

        public string Barcode{get;set;}
    }
}