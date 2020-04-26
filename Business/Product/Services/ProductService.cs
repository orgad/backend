using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Product.ViewModels;
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
            return wms.TProdProducts.Select(x => new VBasicData { id = x.Id, code = x.Code, name = x.Name }).ToList();
        }

        public bool Create(VProdAddForm prod)
        {
            var oldProd = wms.TProdProducts.Where(x => x.Code == prod.Code).FirstOrDefault();
            if (oldProd == null)
            {
                TProdProduct t = new TProdProduct
                {
                    Code = prod.Code,
                    Name = prod.Name,
                    BrandId = prod.BrandId,
                    BrandCode = prod.BrandCode
                };

                t.CreatedBy = DefaultUser.UserName;
                t.CreatedTime = DateTime.UtcNow;
                wms.TProdProducts.Add(t);
                return wms.SaveChanges() > 0;
            }
            else
                return false;
        }
    }
}