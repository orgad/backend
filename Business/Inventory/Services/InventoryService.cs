using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public partial class InventoryService
    {
        wmsinventoryContext wmsinventory = new wmsinventoryContext();

        private Tuple<int, string, int, string> GetDefalutBin(long whId)
        {
            WhService whService = new WhService();
            return whService.getRcvDefaultBin(whId);
        }

        public List<TInvt> PageList(QueryInvt queryInvt)
        {
            if (queryInvt.PageSize == 0) queryInvt.PageSize = 20;
            return this.Query(queryInvt).
            OrderByDescending(x => x.Id).Skip(queryInvt.PageIndex).Take(queryInvt.PageSize).ToList();
        }

        public int TotalCount(QueryInvt queryInvt)
        {
            return this.Query(queryInvt).Count();
        }

        private IQueryable<TInvt> Query(QueryInvt queryInvt)
        {
            if (queryInvt.PageSize == 0)
            {
                queryInvt.PageSize = 20;
            }
            var query = wmsinventory.TInvts as IQueryable<TInvt>;
            if (queryInvt.SkuId > 0)
            {
                query = query.Where(x => x.SkuId == queryInvt.SkuId);
            }
            if (!string.IsNullOrEmpty(queryInvt.Barcode))
            {
                query = query.Where(x => x.Barcode == queryInvt.Barcode);
            }
            return query;
        }

        private void ReduceQty(int totalQty, TInvt invt, List<TInvtD> invtds)
        {
            foreach (var invtd in invtds)
            {
                var canQty = invtd.Qty - invtd.AlotQty - invtd.LockedQty;

                if (totalQty > 0 && canQty > 0)
                {
                    if (invtd.Qty >= totalQty)
                    {
                        if (invt != null) invt.Qty -= totalQty;
                        invtd.Qty -= totalQty;
                        break;
                    }
                    else
                    {
                        if (invt != null) invt.Qty = 0;
                        totalQty -= invtd.Qty;
                        invtd.Qty = 0;
                    }
                }
            }
        }
    }
}