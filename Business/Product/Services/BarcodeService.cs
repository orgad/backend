using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Product.Models;

namespace dotnet_wms_ef.Product.Services
{
    public class BarcodeService
    {
        wmsproductContext wms = new wmsproductContext();
        public List<TProdBarcode> PageList(int page)
        {
            return wms.TProdBarcodes.ToList();
        }

        public int TotalCount()
        {
            return wms.TProdBarcodes.Count();
        }
    }
}