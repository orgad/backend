using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class WhService
    {
        wmswarehouseContext wms = new wmswarehouseContext();
        public List<TWhWarehouse> PageList(int page)
        {
            return wms.TWhWarehouse.ToList();
        }

        public int TotalCount()
        {
            return wms.TWhWarehouse.Count();
        }

        public Tuple<int, string, int, string> getRcvDefaultBin(long whId)
        {
            var r = wms.TWhBins.Join(wms.TWhZones.Where(x => x.TypeCode == "RCV")
            , p => p.ZoneId, c => c.Id,
            (p, c) => new
            {
                WhId = c.WhId,
                ZoneId = c.Id,
                ZoneCode = c.Code,
                BinId = p.Id,
                BinCode = p.Code
            });
            var t = r.Where(x => x.WhId == whId).FirstOrDefault();
            if (t != null)
                return new Tuple<int, string, int, string>(t.ZoneId, t.ZoneCode, t.BinId, t.BinCode);
            else
                return null;
        }
    }
}