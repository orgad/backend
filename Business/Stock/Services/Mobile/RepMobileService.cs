using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.ViewModels;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Stock.Services
{
    public class RepMobileService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();
        BinService binService = new BinService();
        public List<TInvtReplenish> TaskPageList()
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

        private IQueryable<TInvtReplenish> Query()
        {
            return wmsstock.TInvtReplenishs.OrderByDescending(x => x.Id)
            as IQueryable<TInvtReplenish>;
        }

        public VScanResponse MoveDown(long id, VMoveScan request)
        {
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);

            var move = wmsstock.TInvtMoves.Where(x => x.Id == id).FirstOrDefault();

            var zoneBin = binService.GetBinByCode(move.WhId, request.BinCode);

            TInvtDown down = new TInvtDown();
            down.HId = id;
            down.Code = move.Code;
            down.TypeCode = "RepDown";
            down.Carton = request.Carton;
            down.Barcode = request.Barcode;
            down.FromZoneId = zoneBin.ZoneId;
            down.FromZoneCode = zoneBin.ZoneCode;
            down.FromBinId = zoneBin.Id;
            down.FromBinCode = request.BinCode;
            down.Carton = request.Carton;
            down.SkuId = prodSku.Id;
            down.Sku = prodSku.Code;
            down.Qty = 1;
            down.CreatedBy = DefaultUser.UserName;
            down.CreatedTime = DateTime.UtcNow;

            wmsstock.TInvtDowns.Add(down);

            wmsstock.SaveChanges();

            return new VScanResponse();
        }

        public VScanResponse MoveUp(long id, string code, VMoveScan request)
        {
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);
            var move = wmsstock.TInvtMoves.Where(x => x.Id == id).FirstOrDefault();
            var zoneBin = binService.GetBinByCode(move.WhId, request.BinCode);

            TInvtUp up = new TInvtUp();
            up.HId = id;
            up.Code = code;
            up.TypeCode = "RepUp";
            up.Carton = request.Carton;
            up.Barcode = request.Barcode;
            up.ToZoneId = zoneBin.ZoneId;
            up.ToZoneCode = zoneBin.ZoneCode;
            up.ToBinId = zoneBin.Id;
            up.ToBinCode = request.BinCode;
            up.Carton = request.Carton;
            up.SkuId = prodSku.Id;
            up.Sku = prodSku.Code;
            up.Qty = 1;
            up.CreatedBy = DefaultUser.UserName;
            up.CreatedTime = DateTime.UtcNow;
            wmsstock.TInvtUps.Add(up);

            wmsstock.SaveChanges();
            return new VScanResponse();
        }
    }
}