using System.Collections.Generic;
using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VWaveDetails
    {
        public TOutWave Wave {get;set;}

        public ICollection<TOutPick> DetailList{get;set;}
    }
}