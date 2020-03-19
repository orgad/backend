using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.ViewModels
{
    public class VOutboundDetails
    {
         public TOut Outbound{get;set;}

         public TOutD[] DetailList{get;set;}
    }
}