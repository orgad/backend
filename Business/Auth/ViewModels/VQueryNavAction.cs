using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Auth.ViewModels
{
    public class VQueryNavAction : PagedParams
    {
        public int NavId { get; set; }
        public string NavCode { get; set; }
    }
}