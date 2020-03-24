using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class SupplierService
    {
        wmssupplierContext wmssupplier = new wmssupplierContext();

         public List<TSupSupplier> PageList(int page)
        {
            return wmssupplier.TSupSuppliers.ToList();
        }

        public int TotalCount()
        {
            return wmssupplier.TSupSuppliers.Count();
        }
    }
}