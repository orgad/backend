using dotnet_wms_ef.Inbound.Models;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VInboundDetails
    {
        public TInInbound Inbound{get;set;}

        public TInInboundD[] InboundDs{get;set;}
    }
}