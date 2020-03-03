using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class CustService
    {
        wmscustomerContext wms = new wmscustomerContext();
        public List<TCustCustomer> PageList(int page)
        {
            return wms.TCustCustomer.ToList();
        }

        public int TotalCount()
        {
            return wms.TCustCustomer.Count();
        }
    }
}