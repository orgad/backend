
using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.ViewModels;

namespace dotnet_wms_ef.Stock.Services
{
    public class FreezeService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();

        public List<TInvtFreeze> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        private IQueryable<TInvtFreeze> Query()
        {
            return wmsstock.TInvtFreezes.OrderByDescending(x => x.Id)
            as IQueryable<TInvtFreeze>;
        }

        public VFreezeDetails Details(long id)
        {
            var o = wmsstock.TInvtFreezes.Where(x => x.Id == id).FirstOrDefault();
            var l = wmsstock.TInvtFreezeLimits.Where(x => x.HId == id).ToList();
            var d = wmsstock.TInvtFreezeDs.Where(x => x.HId == id).ToList();

            return new VFreezeDetails
            {
                StockFreeze = o,
                Limits = l,
                Details = d
            };
        }

        public bool Create(VFreezeAddForm vFreeze)
        {
            TInvtFreeze freeze = new TInvtFreeze();
            freeze.Code = "HLD" + DateTime.Now.ToString(FormatString.DefaultFormat);
            freeze.TypeMode = vFreeze.TypeMode;
            freeze.ReasonCode = vFreeze.ReasonCode;
            freeze.CreatedBy = DefaultUser.UserName;
            freeze.CreatedTime = DateTime.UtcNow;

            List<TInvtFreezeLimits> limits = new List<TInvtFreezeLimits>();
            foreach (var limit in vFreeze.CheckLimits)
            {
                limits.Add(new TInvtFreezeLimits
                {
                    ItemId = limit.ItemId,
                    ItemCode = limit.ItemCode,
                    CreatedBy = DefaultUser.UserName,
                    TypeCode = vFreeze.TypeMode,
                    CreatedTime = DateTime.UtcNow
                });
            }
            freeze.Limits = limits;

            wmsstock.TInvtFreezes.Add(freeze);
            return wmsstock.SaveChanges() > 0;
        }
    }
}