using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class CourierService
    {
        wmssupplierContext wmssupplier = new wmssupplierContext();

         public List<TSupCourier> PageList(int page)
        {
            return wmssupplier.TSupCouriers.ToList();
        }

        public int TotalCount()
        {
            return wmssupplier.TSupCouriers.Count();
        }

        public string GetDefaultCourier()
        {
            var r= wmssupplier.TSupCouriers.FirstOrDefault();
            return r.Code;
        }
    }
}