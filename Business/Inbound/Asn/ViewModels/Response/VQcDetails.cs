using dotnet_wms_ef.Inbound.Models;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    internal class VQcDetails
    {
       public TInQc Qc{get;set;}
        
       public TInQcD[] QcDs{get;set;}
    }
}