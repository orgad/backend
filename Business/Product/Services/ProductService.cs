using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class ProductService
    {
        wmsproductContext wmsproduct = new wmsproductContext();
        public TProdSku GetSkuByBarcode(string barcode)
        {
           return wmsproduct.TProdSkus.Where(x=>x.Barcode == barcode).FirstOrDefault();
        }
    }
}