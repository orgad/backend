using dotnet_wms_ef.Inbound.Models;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VAsnCheckDetails
    {
        public TInAsn Asn { get; set; }

        public TInCheck AsnCheck { get; set; }

        public TInCheckD[] AsnCheckDs { get; set; }
    }

    public class VInCheck : TInCheck
    {
        public int asnCartonQty { get; set; }
        public int asnQty { get; set; }
    }
}