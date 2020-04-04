using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class InboundLogService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();

        public List<TInOptlog> OptList()
        {
            return wmsinbound.TInOptlogs.ToList();
        }

        public int OptTotal()
        {
            return wmsinbound.TInOptlogs.Count();
        }

        public List<TInOptlog> Opt(long id)
        {
            return wmsinbound.TInOptlogs.Where(x => x.OrderId == id).ToList();
        }
    }
}