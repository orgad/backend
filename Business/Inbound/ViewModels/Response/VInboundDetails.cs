using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Views.ViewModels
{
    public class VInboundDetails
    {
        public TInInbound Inbound{get;set;}

        public TInInboundD[] InboundDs{get;set;}
    }
}