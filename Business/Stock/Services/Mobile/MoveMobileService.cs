using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Stock.Services
{
    public class MoveMobileService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();
        public List<TInvtMove> TaskPageList()
        {
            return this.Query()
            //.Where(x => x.ScanStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
            //            x.ScanStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
            .ToList();
        }

        public int TaskTotal()
        {
            return this.Query()
            //  .Where(x => x.ScanStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
            //            x.ScanStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
            .Count();
        }

        private IQueryable<TInvtMove> Query()
        {
            return wmsstock.TInvtMoves.OrderByDescending(x => x.Id)
            as IQueryable<TInvtMove>;
        }

        public VScanResponse MoveDown(VScanRequest request)
        {
            return new VScanResponse();
        }

        public VScanResponse MoveUp(VScanRequest request)
        {
            return new VScanResponse();
        }
    }
}