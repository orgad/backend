using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Views.ViewModels
{
    public class VAsn
    {
        public TInAsn Asn{get;set;}

        public TInAsnD[] AsnDs{get;set;}
    }
}