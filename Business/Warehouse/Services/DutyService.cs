using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class DutyService
    {
        wmswarehouseContext wms = new wmswarehouseContext();

        public TWhDutyracking GetDutyByCode(int whId, string dutyCode)
        {
            return wms.TWhDutyrackings.Where(x => x.WhId == whId && x.Code == dutyCode).FirstOrDefault();
        }

        public List<TWhDutyracking> PageList(int page)
        {
            return wms.TWhDutyrackings.ToList();
        }

        public int TotalCount()
        {
            return wms.TWhDutyrackings.Count();
        }
    }
}