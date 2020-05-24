using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Product.Models;
using dotnet_wms_ef.Product.ViewModels;

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

        public bool Create(VMatAddForm vMat)
        {
            TProdMat mat = new TProdMat{
               Code = vMat.Code,
               Name = vMat.Name,
               Barcode = vMat.Barcode,
               PUom = vMat.PUom,
               AUom = vMat.AUom,
               PToA = vMat.PToA,
               X = vMat.X,
               XUnit = vMat.XUnit,
               Y = vMat.Y,
               YUnit = vMat.YUnit,
               Z = vMat.Z,
               ZUnit = vMat.ZUnit,
            };

            mat.CreatedBy = DefaultUser.UserName;
            mat.CreatedTime = DateTime.UtcNow;

            wmsproduct.TProdMats.Add(mat);

            return wmsproduct.SaveChanges()>0;
        }

    }
}