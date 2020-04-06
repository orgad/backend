using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.ViewModels;
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
            .Where(x => x.UpStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                        x.UpStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init) ||
                        x.DownStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                        x.DownStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
            .ToList();
        }

        public int TaskTotal()
        {
            return this.Query()
              .Where(x => x.UpStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                        x.UpStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init) ||
                        x.DownStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                        x.DownStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
            .Count();
        }

        private IQueryable<TInvtMove> Query()
        {
            return wmsstock.TInvtMoves.OrderByDescending(x => x.Id)
            as IQueryable<TInvtMove>;
        }

        public VScanResponse MoveDown(long id,string code, VMoveScan request)
        {
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);

            TInvtDown down = new TInvtDown();
            down.Id=id;
            down.Code = code;
            down.TypeCode = "MoveDown";
            down.Carton = request.Carton;
            down.Barcode = request.Barcode;
            down.FromZoneId = request.FromZoneId;
            down.FromZoneCode = request.FromZoneCode;
            down.FromBinId = request.FromBinId;
            down.FromBinCode = request.FromBinCode;
            down.Carton = request.Carton;
            down.SkuId = prodSku.Id;
            down.Sku = prodSku.Code;
            down.Qty = 1;
            down.CreatedBy = DefaultUser.UserName;
            down.CreatedTime = DateTime.UtcNow;

            wmsstock.TInvtDown.Add(down);

            wmsstock.SaveChanges();

            return new VScanResponse();
        }

        public VScanResponse MoveUp(long id,string code, VMoveScan request)
        {
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);


            TInvtUp up = new TInvtUp();
            up.HId = id;
            up.Code = code;
            up.TypeCode = "MoveUp";
            up.Carton = request.Carton;
            up.Barcode = request.Barcode;
            up.ToZoneId = request.ToZoneId;
            up.ToZoneCode = request.ToZoneCode;
            up.ToBinId = request.ToBinId;
            up.ToBinCode = request.ToBinCode;
            up.Carton = request.Carton;
            up.SkuId = prodSku.Id;
            up.Sku = prodSku.Code;
            up.Qty = 1;
            up.CreatedBy = DefaultUser.UserName;
            up.CreatedTime = DateTime.UtcNow;
            wmsstock.TInvtUp.Add(up);

            wmsstock.SaveChanges();
            return new VScanResponse();
        }
    }
}