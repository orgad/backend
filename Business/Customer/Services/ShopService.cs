using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class ShopService
    {
        wmscustomerContext wms = new wmscustomerContext();
        public List<TCustShop> PageList(int page)
        {
            return wms.TCustShops.ToList();
        }

        public List<TCustShop> PageListByCustId(int custId)
        {
             return wms.TCustShops.Where(x=>x.CustId == custId).ToList();
        }

        public int TotalCount()
        {
            return wms.TCustShops.Count();
        }
    }
}