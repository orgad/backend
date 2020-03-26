using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class CatalogService
    {
        wmsproductContext wms = new wmsproductContext();
        public List<TProdCatalog> PageList(int page)
        {
            return wms.TProdCatalogs.ToList();
        }

        public int TotalCount()
        {
            return wms.TProdCatalogs.Count();
        }
    }
}