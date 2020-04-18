using dotnet_wms_ef.Inbound.Models;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    internal class VPutAwayDetails
    {
       public TInPutaway PutAway{get;set;}
        
       public TInPutawayD[] PutAwayDs{get;set;}
    }
}