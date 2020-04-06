using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VOutStDetails
    {
        public TOutSt TOutSt { get; set; }

        public TOutStD[] TOutStDs { get; set; }

        public TStDelivery TOutStDelivery { get; set; }

        public TStAllot[] TOutStAlots { get; set; }

        public TStWave[] TOutStWaves { get; set; }

        public TStPick TOutStPick { get; set; }

    }
}