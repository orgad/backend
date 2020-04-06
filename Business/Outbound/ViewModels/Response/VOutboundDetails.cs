using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VOutboundDetails
    {
         public TOut Outbound{get;set;}

         public TOutD[] DetailList{get;set;}
    }
}