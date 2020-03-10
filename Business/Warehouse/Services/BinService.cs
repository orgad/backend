using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class BinService
    {
        wmswarehouseContext wms = new wmswarehouseContext();
        
        public TWhBin GetBinByCode(int whId,string binCode)
        {
            return wms.TWhBins.Where(x=>x.WhId==whId && x.Code == binCode).FirstOrDefault();
        }
    }
}