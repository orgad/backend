using dotnet_wms_ef.Outbound.Models;
using System.Linq;

namespace dotnet_wms_ef.Outbound.Services
{
    public class OutStrategyService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();
        public TStWave WaveSt(long whId,long custId,long brandId)
        {
           var query = from waveSt in wmsoutbound.TStWaves
                          join st in wmsoutbound.TSts on waveSt.HId equals st.Id
                          where st.WhId == whId && st.CustId == custId && st.BrandId == brandId
                          select waveSt;

           return query.FirstOrDefault();
        }
    }
}