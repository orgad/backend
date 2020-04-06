using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.ViewModels;

namespace dotnet_wms_ef.Stock.Services
{
    public class MoveService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();

        public List<TInvtMove> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        private IQueryable<TInvtMove> Query()
        {
            return wmsstock.TInvtMoves.OrderByDescending(x => x.Id)
            as IQueryable<TInvtMove>;
        }

        public bool Create(VMoveAddForm vMove)
        {
            TInvtMove tMove = new TInvtMove();
            tMove.Code = "MOV" + DateTime.Now.ToString(FormatString.DefaultFormat);
            tMove.TypeCode = "Direct";
            tMove.FromZoneId = vMove.FromZoneId;
            tMove.FromZoneCode = vMove.FromZoneCode;
            tMove.FromBinId = vMove.FromBinId;
            tMove.FromBinCode = vMove.FromBinCode;
            tMove.Carton = vMove.Carton;
            tMove.SkuId = vMove.SkuId;
            tMove.Sku = vMove.Sku;
            tMove.Qty = vMove.Qty;
            tMove.Status = Enum.GetName(typeof(EnumStatus),EnumStatus.None);
            tMove.CreatedBy = DefaultUser.UserName;
            tMove.CreatedTime = DateTime.UtcNow;

            return wmsstock.SaveChanges() > 0;
        }
    }
}