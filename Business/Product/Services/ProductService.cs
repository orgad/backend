using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class ProductService
    {
        wmsproductContext wms = new wmsproductContext();
        public List<TProdProduct> PageList(int page)
        {
            return wms.TProdProducts.ToList();
        }

        public int TotalCount()
        {
            return wms.TProdProducts.Count();
        }
    }
}