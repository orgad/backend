using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class QueryPutAway : PagedParams
    {
        public string status { get; set; }
    }
}