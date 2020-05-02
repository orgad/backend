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
            return this.Query().ToList();
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        private IQueryable<TProdCatalog> Query()
        {
            return wms.TProdCatalogs
                   .OrderBy(x => x.CatLvl1).ThenBy(x => x.CatLvl2).ThenBy(x => x.CatLvl3)
            as IQueryable<TProdCatalog>;
        }
    }
}