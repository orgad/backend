using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class ZoneService
    {
        wmswarehouseContext wms = new wmswarehouseContext();

        public TWhZone GetZoneByCode(int whId, string zoneCode)
        {
            return wms.TWhZones.Where(x => x.WhId == whId && x.Code == zoneCode).FirstOrDefault();
        }

        public List<TWhZone> PageList(int page)
        {
            return wms.TWhZones.ToList();
        }

        public int TotalCount()
        {
            return wms.TWhZones.Count();
        }
    }
}