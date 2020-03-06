using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.ViewModels
{
    public class VAsnCheck
    {
        public TInAsn Asn{get;set;}

        public TInCheck AsnCheck{get;set;}

        public TInCheckD[] AsnCheckDs{get;set;}
    }
}