using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    internal class VPutAwayDetails
    {
       public TInPutaway PutAway{get;set;}
        
       public TInPutawayD[] PutAwayDs{get;set;}
    }
}