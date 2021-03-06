using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Mobile.Invt.ViewModels;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class InventoryDetailService
    {
        wmsinventoryContext wmsinventory = new wmsinventoryContext();
        public List<TInvtD> PageList(QueryInvt queryInvt)
        {
            if (queryInvt.PageSize == 0) queryInvt.PageSize = 20;
            return this.Query(queryInvt).
            OrderByDescending(x => x.Id).Skip(queryInvt.PageIndex).Take(queryInvt.PageSize).ToList();
        }

        public int TotalCount(QueryInvt queryInvt)
        {
            return this.Query(queryInvt).Count();
        }

        private IQueryable<TInvtD> Query(QueryInvt queryInvt)
        {
            if (queryInvt.PageSize == 0)
            {
                queryInvt.PageSize = 20;
            }

            var query = wmsinventory.TInvtDs as IQueryable<TInvtD>;
            
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

        public VSkuBarcodeBin[] GetInvtByBarcode(string barcode)
        {
            var list = wmsinventory.TInvtDs.Where(x=>x.Barcode==barcode)
            .GroupBy(y=>new{y.Barcode,y.BinCode})
            .Select(x=>new VSkuBarcodeBin{
                Barcode = x.Key.Barcode,
                BinCode = x.Key.BinCode,
                Qty = x.Sum(y=>y.Qty)
            });
            
            return list.ToList().ToArray();
        }

        public VSkuBarcodeBin[] GetInvtByBinCode(string binCode)
        {
            var list = wmsinventory.TInvtDs.Where(x=>x.BinCode==binCode)
            .GroupBy(y=>new{y.Barcode,y.BinCode})
            .Select(x=>new VSkuBarcodeBin{
                Barcode = x.Key.Barcode,
                BinCode = x.Key.BinCode,
                Qty = x.Sum(y=>y.Qty)
            });
            
            return list.ToList().ToArray();
        }

        public VSkuBarcodeBin[] GetGroupBySkus(long[] ids)
        {
             var list = wmsinventory.TInvtDs.Where(x=>ids.Contains(x.SkuId))
            .GroupBy(y=>new{y.Barcode,y.BinCode})
            .Select(x=>new VSkuBarcodeBin{
                Barcode = x.Key.Barcode,
                BinCode = x.Key.BinCode,
                Qty = x.Sum(y=>y.Qty)
            });
            
            return list.ToList().ToArray();
        }

        public VSkuBarcodeBin[] GetGroupByBinIds(int[] ids)
        {
             var list = wmsinventory.TInvtDs.Where(x=>ids.Contains(x.BinId))
            .GroupBy(y=>new{y.Barcode,y.BinCode})
            .Select(x=>new VSkuBarcodeBin{
                Barcode = x.Key.Barcode,
                BinCode = x.Key.BinCode,
                Qty = x.Sum(y=>y.Qty)
            });
            
            return list.ToList().ToArray();
        }
    }
}