using dotnet_wms_ef.Inbound.Models;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VAsnDetails
    {
        public TInAsn Asn{get;set;}

        public TInAsnD[] AsnDs{get;set;}
    }
}