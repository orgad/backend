using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class QueryPick:PagedParams
    {
        public int WaveId{get;set;}
    }
}