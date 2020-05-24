using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Product.Services;
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

        InventoryService inventoryService = new InventoryService();
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
            //移货下架的时候锁定库存
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
                    //更新冻结数量
                    inventoryService.Locked(new VInvtData
                    {
                        ZoneId = move.FromZoneId,
                        ZoneCode = move.FromZoneCode,
                        BinId = move.FromBinId,
                        BinCode = move.FromBinCode,
                        SkuId = move.SkuId,
                        Sku = move.Sku,
                        Barcode = move.Barcode,
                        Qty = move.Qty
                    });
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
            //移货上架会释放锁定数
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

                    //更新上架数量
                    inventoryService.UnlockAndMove(move.Id, move.Code, move.WhId, 0,
                        new VInvtData
                        {
                            ZoneId = move.FromZoneId,
                            ZoneCode = move.FromZoneCode,
                            BinId = move.FromBinId,
                            BinCode = move.FromBinCode,
                            SkuId = move.SkuId,
                            Sku = move.Sku,
                            Barcode = move.Barcode,
                            Qty = move.Qty
                        },
                    new VInvtData
                    {
                        ZoneId = move.ToZoneId,
                        ZoneCode = move.ToZoneCode,
                        BinId = move.ToBinId,
                        BinCode = move.ToBinCode,
                        SkuId = move.SkuId,
                        Sku = move.Sku,
                        Barcode = move.Barcode,
                        Qty = move.Qty
                    }
                    );
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