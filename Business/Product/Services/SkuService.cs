using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Product.Services;

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

        public bool Create(VSkuAddForm sku)
        {
            TProdSku tSku = new TProdSku();

            tSku.Code = sku.Code;
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
            return wmsproduct.SaveChanges()>0;
        }
    }
}