using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

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

        public List<VBasicData> OuterList()
        {
            return wms.TProdProducts.Select(x=>new VBasicData{id = x.Id,code = x.Code,name = x.Name}).ToList();
        }
    }
}