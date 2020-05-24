using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Product.Services;
using dotnet_wms_ef.Stock.Models;

namespace dotnet_wms_ef.Stock.Services
{
    public class UnfreezeService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();

        public List<TInvtUnfreeze> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        private IQueryable<TInvtUnfreeze> Query()
        {
            return wmsstock.TInvtUnfreezes.OrderByDescending(x => x.Id)
            as IQueryable<TInvtUnfreeze>;
        }

        private bool Create(TInvtUnfreeze vUnfreeze)
        {
            TInvtUnfreeze unfreeze = new TInvtUnfreeze
            {
                FreezeId = vUnfreeze.FreezeId,
                FreezeDId = vUnfreeze.FreezeDId,
                ZoneId = vUnfreeze.ZoneId,
                ZoneCode = vUnfreeze.ZoneCode,
                BinId = vUnfreeze.BinId,
                BinCode = vUnfreeze.BinCode,
                SkuId = vUnfreeze.SkuId,
                Sku = vUnfreeze.Sku,
                Barcode = vUnfreeze.Barcode,
                Qty = vUnfreeze.Qty,
            };

            unfreeze.CreatedBy = DefaultUser.UserName;
            unfreeze.CreatedTime = DateTime.UtcNow;
            wmsstock.TInvtUnfreezes.Add(unfreeze);
            return wmsstock.SaveChanges() > 0;
        }
    }
}