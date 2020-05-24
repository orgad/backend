using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Product.Models;

namespace dotnet_wms_ef.Product.Services
{
    public class SkuService
    {
        wmsproductContext wmsproduct = new wmsproductContext();
        public TProdSku GetSkuByBarcode(string barcode)
        {
            return wmsproduct.TProdSkus.Where(x => x.Barcode == barcode).FirstOrDefault();
        }

        public List<TProdSku> PageList(int page)
        {
            return wmsproduct.TProdSkus.ToList();
        }

        public int TotalCount()
        {
            return wmsproduct.TProdSkus.Count();
        }

        public bool Create(VSkuAddForm sku)
        {

            TProdSku tSku = new TProdSku();
            if (sku.Code == null)
                tSku.Code = sku.Barcode;
            else
                tSku.Code = sku.Code;
            var oldSku = wmsproduct.TProdSkus.Where(x => x.Barcode == sku.Barcode).FirstOrDefault();
            if (oldSku == null)
            {
                tSku.Barcode = sku.Barcode;
                tSku.ProductId = sku.ProductId;
                tSku.ProductCode = sku.ProductCode;
                tSku.Season = sku.Season;
                tSku.Style = sku.Style;
                tSku.Color = sku.Color;
                tSku.Size = sku.Size;
                tSku.IsLot = sku.IsLot;
                tSku.IsSerial = sku.IsSerial;
                tSku.CreatedBy = DefaultUser.UserName;
                tSku.CreatedTime = DateTime.UtcNow;

                wmsproduct.TProdSkus.Add(tSku);
                return wmsproduct.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}