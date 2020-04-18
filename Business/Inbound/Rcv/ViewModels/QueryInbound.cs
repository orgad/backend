using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class QueryInbound : PagedParams
    {
        public string TransCode { get; set; }
    }
}