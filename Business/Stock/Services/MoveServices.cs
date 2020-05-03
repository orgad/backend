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
        BinService binService = new BinService();

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
            var prodSku = skuService.GetSkuByBarcode(vMove.Barcode);

            TInvtMove tMove = new TInvtMove();
            tMove.WhId = vMove.WhId;
            tMove.Code = "MOV" + DateTime.Now.ToString(FormatString.DefaultFormat);
            tMove.TypeCode = "Direct";
            tMove.FromZoneId = vMove.FromZoneId;
            tMove.FromZoneCode = vMove.FromZoneCode;
            tMove.FromBinId = vMove.FromBinId;
            tMove.FromBinCode = vMove.FromBinCode;
            tMove.ToZoneId = vMove.ToZoneId;
            tMove.ToZoneCode = vMove.ToZoneCode;
            tMove.ToBinId = vMove.ToBinId;
            tMove.ToBinCode = vMove.ToBinCode;
            tMove.Carton = vMove.Carton;
            tMove.SkuId = prodSku.Id;
            tMove.Sku = vMove.Sku;
            tMove.Barcode = vMove.Barcode;
            tMove.Qty = vMove.Qty;
            tMove.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.None);
            tMove.DownStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
            tMove.CreatedBy = DefaultUser.UserName;
            tMove.CreatedTime = DateTime.UtcNow;

            wmsstock.TInvtMoves.Add(tMove);

            return wmsstock.SaveChanges() > 0;
        }

        public bool Confirm(long id)
        {
            //将单据状态置为已完成
            var move = wmsstock.TInvtMoves.Where(x => x.Id == id).FirstOrDefault();
            move.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Finished);
            return wmsstock.SaveChanges() > 0;
        }
    }
}