using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class SkuService
    {
        wmsproductContext wmsproduct = new wmsproductContext();
        public TProdSku GetSkuByBarcode(string barcode)
        {
           return wmsproduct.TProdSkus.Where(x=>x.Barcode == barcode).FirstOrDefault();
        }

        public List<TProdSku> PageList(int page)
        {
            return wmsproduct.TProdSkus.ToList();
        }

        public int TotalCount()
        {
            return wmsproduct.TProdSkus.Count();
        }
    }
}