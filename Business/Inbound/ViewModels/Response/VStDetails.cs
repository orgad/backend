using System.Collections.Generic;
using dotnet_wms_ef.Inbound.Models;

namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VInStDetails
    {
        public TSt TSt { get; set; }

        public List<TStD> TStDs { get; set; }

        public TStRcv TStRcv { get; set; }

        public TStPutaway TStPutAway { get; set; }
    }
}