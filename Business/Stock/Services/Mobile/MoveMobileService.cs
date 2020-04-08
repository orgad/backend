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
        BinService binService = new BinService();
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

        public VScanResponse MoveDown(long id, VMoveScan request)
        {
            var result = new VScanResponse();
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);
            var move = wmsstock.TInvtMoves.Where(x => x.Id == id).FirstOrDefault();
            var zoneBin = binService.GetBinByCode(move.WhId, request.BinCode);
            var downs = wmsstock.TInvtDowns.Where(x => x.HId == id).Count();
            if (downs + 1 <= move.Qty)
            {
                TInvtDown down = new TInvtDown();
                down.HId = id;
                down.Code = move.Code;
                down.TypeCode = "MoveDown";
                down.Carton = request.Carton;
                down.Barcode = request.Barcode;
                down.ToZoneId = zoneBin.ZoneId;
                //down.FromZoneCode = request.FromZoneCode;
                down.ToBinId = zoneBin.Id;
                //down.FromBinCode = request.FromBinCode;
                down.Carton = request.Carton;
                down.SkuId = prodSku.Id;
                down.Sku = prodSku.Code;
                down.Qty = 1;
                down.CreatedBy = DefaultUser.UserName;
                down.CreatedTime = DateTime.UtcNow;

                wmsstock.TInvtDowns.Add(down);
                move.DownStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
                wmsstock.SaveChanges();

                if (downs + 1 == move.Qty)
                {
                    result.IsAllFinished = true;
                    result.Message = string.Format("{0}/{1}", downs + 1, move.Qty);
                    move.DownStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Done);
                    move.UpStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
                }
            }
            else
            {
                result.IsAllFinished = true;
                result.Message = string.Format("{0}/{1}", move.Qty, move.Qty);
            }
            return result;
        }

        public VScanResponse MoveUp(long id, VMoveScan request)
        {
            var result = new VScanResponse();
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);
            var move = wmsstock.TInvtMoves.Where(x => x.Id == id).FirstOrDefault();
            var zoneBin = binService.GetBinByCode(move.WhId, request.BinCode);

            var ups = wmsstock.TInvtUps.Where(x => x.HId == id).Count();
            if (ups + 1 <= move.Qty)
            {
                TInvtUp up = new TInvtUp();
                up.HId = id;
                up.Code = move.Code;
                up.TypeCode = "MoveUp";
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

                move.UpStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
                wmsstock.SaveChanges();

                if (ups + 1 == move.Qty)
                {
                    result.IsAllFinished = true;
                    result.Message = string.Format("{0}/{1}", ups + 1, move.Qty);
                    move.UpStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Done);
                }
            }
            else
            {
                result.IsAllFinished = true;
                result.Message = string.Format("{0}/{1}", move.Qty, move.Qty);
            }
            return result;
        }
    }
}