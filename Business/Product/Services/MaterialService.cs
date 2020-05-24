using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Product.Models;

namespace dotnet_wms_ef.Product.Services
{
    public class MaterialService
    {
         wmsproductContext wmsproduct = new wmsproductContext();
        public TProdMat GetMatByBarcode(string barcode)
        {
            return wmsproduct.TProdMats.Where(x => x.Barcode == barcode).FirstOrDefault();
        }

         public List<TProdMat> PageList(int page)
        {
            return wmsproduct.TProdMats.ToList();
        }

        public int TotalCount()
        {
            return wmsproduct.TProdMats.Count();
        }

    }
}