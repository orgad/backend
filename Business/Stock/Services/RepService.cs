using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.ViewModels;

namespace dotnet_wms_ef.Stock.Services
{
    public class RepService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();

        public List<TInvtReplenish> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        private IQueryable<TInvtReplenish> Query()
        {
            return wmsstock.TInvtReplenishs.OrderByDescending(x => x.Id)
            as IQueryable<TInvtReplenish>;
        }

        public bool Create(VRepAddForm request)
        {
            var rep = new TInvtReplenish();

            rep.Code = "RET"+ DateTime.Now.ToString(FormatString.DefaultFormat);
            rep.WhId = request.WhId;
            rep.CreatedBy = DefaultUser.UserName;
            rep.CreatedTime = DateTime.UtcNow;
            rep.Status =Enum.GetName(typeof(EnumStatus),EnumStatus.None);

            wmsstock.TInvtReplenishs.Add(rep);

            return wmsstock.SaveChanges()>0;
        }
    }
}