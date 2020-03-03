using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class BrandService
    {
        wmscustomerContext wms = new wmscustomerContext();
        public List<TCustBrand> PageList(int page)
        {
            return wms.TCustBrand.ToList();
        }

        public List<TCustBrand> PageListByCustId(int custId)
        {
             return wms.TCustBrand.Where(x=>x.CustId == custId).ToList();
        }

        public int TotalCount()
        {
            return wms.TCustBrand.Count();
        }
    }
}