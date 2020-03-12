using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    internal class VQcDetails
    {
       public TInQc Qc{get;set;}
        
       public TInQcD[] QcDs{get;set;}
    }
}