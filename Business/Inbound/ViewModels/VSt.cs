using System.Collections.Generic;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.ViewModels
{
    public class VInSt
    {
        public TSt TSt { get; set; }

        public List<TStD> TStDs { get; set; }

        public TStRcv TStRcv { get; set; }

        public TStPutaway TStPutAway { get; set; }
    }
}