using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Outbound.Models;
using dotnet_wms_ef.Outbound.ViewModels;
using dotnet_wms_ef.Services;
using Microsoft.EntityFrameworkCore.Storage;

namespace dotnet_wms_ef.Outbound.Services
{
    public class PickService
    {
        public wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        SkuService skuService = new SkuService();

        BinService binService = new BinService();

        public void UseTransaction(IDbContextTransaction transaction)
        {
            if (transaction != null)
            {
                //wmsoutbound.Database.UseTransaction(transaction.GetDbTransaction());
            }
        }
        
        ///这里不对TOut的状态做任何校验
        public bool CreatePick(TOut tOut, long waveId = 0)
        {
            TOutPick tOutPick = new TOutPick
            {
                Code = tOut.Code.Replace("SHP", "PCK"),
                WhId = tOut.WhId,
                WaveId = waveId,
                OutboundId = tOut.Id,
                OutboundCode = tOut.Code,
                Store = tOut.Store,
                Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init),
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };

            tOut.DetailList = wmsoutbound.TOutDs.Where(x => x.HId == tOut.Id).ToList();

            var alotDetailList = (from detail in wmsoutbound.TOutAlotDs
                                  join alot in wmsoutbound.TOutAlots on detail.HId equals alot.Id
                                  where alot.OutboundId == tOut.Id
                                  select detail)
                                 .ToList();

            var detaiList = tOut.DetailList;

            foreach (var detail in alotDetailList)
            {
                for (int i = 0; i < detail.MatchingQty; i++)
                {
                    var outDetail = detaiList.Where(x => x.SkuId == detail.SkuId).FirstOrDefault();
                    TOutPickD tOutPickD = new TOutPickD
                    {
                        SkuId = detail.SkuId,
                        Sku = outDetail.Sku,
                        Barcode = detail.Barcode,
                        ZoneId = detail.ZoneId,
                        ZoneCode = detail.ZoneCode,
                        BinId = detail.BinId,
                        BinCode = detail.BinCode,
                        Qty = 1,
                        CreatedBy = DefaultUser.UserName,
                        CreatedTime = DateTime.UtcNow
                    };

                    tOutPick.DetailList.Add(tOutPickD);
                }
            }

            wmsoutbound.TOutPicks.Add(tOutPick);
            return wmsoutbound.SaveChanges() > 0;
        }

        public List<TOutPick> PageList(QueryPick queryPick)
        {
            return this.Query(queryPick).ToList();
        }

        public int TotalCount(QueryPick queryPick)
        {
            return this.Query(queryPick).Count();
        }

        public List<TOutPick> TaskPageList(QueryPick queryPick)
        {
            return this.Query(queryPick)
            .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                   x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
            .ToList();
        }

        public int TaskTotalCount(QueryPick queryPick)
        {
            return this.Query(queryPick)
            .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                   x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
            .Count();
        }

        private IQueryable<TOutPick> Query(QueryPick queryPick)
        {
            if (queryPick.PageSize == 0)
                queryPick.PageSize = 20;

            var query = wmsoutbound.TOutPicks.Where(x => x.WaveId == queryPick.WaveId)
            .OrderByDescending(x => x.Id);

            return query;
        }

        public VPickDetails Details(long pickId)
        {
            var pick = wmsoutbound.TOutPicks.Where(x => x.Id == pickId).FirstOrDefault();
            var detailList = wmsoutbound.TOutPickDs.Where(x => x.HId == pickId).ToArray();

            return new VPickDetails { Pick = pick, DetailList = detailList };
        }

        public TOutPick GetPickByOutbound(long outboundId)
        {
            var outbound = wmsoutbound.TOutPicks.Where(x=>x.OutboundId==outboundId).FirstOrDefault();
            return outbound;
        }

        public VPickAdvice Advice(long pickId)
        {
            //找到已经存在的拣货记录
            var detailList = wmsoutbound.TOutPickDs.Where(x => x.HId == pickId);

            var binCodes = detailList.Where(x => !x.IsPicked).Select(x => x.BinCode).OrderBy(x => x).Distinct();

            //查询当前货位的barcode列表
            var binCode = binCodes.FirstOrDefault();

            var barcodes = detailList.Select(x => x.Barcode).Distinct().ToArray();

            return new VPickAdvice { BinCode = binCode, Barcodes = barcodes };
        }

        public VPickScanResponse Scan(long pickId, VScanBinRequest detail)
        {
            VPickScanResponse response = new VPickScanResponse
            {
                AllFinished = false,
                BinFinished = false,
                Message = ""
            };

            var pick = wmsoutbound.TOutPicks.Where(x => x.Id == pickId).FirstOrDefault();
            if (pick == null)
            {
                throw new Exception("pick is not exist.");
            }

            //获取SKU信息
            var prodSku = skuService.GetSkuByBarcode(detail.Barcode);
            if (prodSku == null)
            {
                throw new Exception("barcode is not exist.");
            }

            //获取货区货位信息
            var zoneBin = binService.GetBinByCode(pick.WhId, detail.BinCode);
            if (zoneBin == null)
            {
                throw new Exception("zoneBin is not exist.");
            }

            //更新拣货明细
            var pickDetail = wmsoutbound.TOutPickDs.Where(x => x.HId == pickId && x.Barcode == detail.Barcode && !x.IsPicked).FirstOrDefault();
            if (pickDetail == null)
            {
                throw new Exception("pickDetail is not exist.");
            }

            //计算每个条码的需要扫描的总数量和货位数量
            var skuAllQty = wmsoutbound.TOutPickDs.Where(x => x.HId == pick.Id && x.Barcode == detail.Barcode).Count();
            var pickAllQty = wmsoutbound.TOutPickDs.Where(x => x.HId == pick.Id && x.Barcode == detail.Barcode && x.IsPicked).Count();

            //计算每个条码的当前货位需要扫描的数量
            var skuBinQty = wmsoutbound.TOutPickDs.Where(x => x.HId == pickId && x.Barcode == detail.Barcode && x.BinCode == detail.AdvBinCode).Count();

            //计算每个条码的当前货位已扫描的数量
            var pickBinQty = wmsoutbound.TOutPickDs.Where(x => x.HId == pickId && x.Barcode == detail.Barcode
                  && x.BinCode == detail.AdvBinCode && x.IsPicked).Count();

            //计算当前货位是否已经都扫描完毕了,如果是的话,需要跳转到下一个货位的
            if (skuAllQty == pickAllQty)
            {
                response.AllFinished = true;
                response.Message = string.Format("{0}/{1}/{2}", skuBinQty, skuBinQty, skuAllQty);
            }
            else if (pickBinQty + 1 <= skuBinQty)
            {
                response.BinFinished = true;
                UpdatePickDetail(zoneBin, pick, pickDetail);
                response.Message = string.Format("{0}/{1}/{2}", pickBinQty + 1, skuBinQty, skuAllQty);
            }

            return response;
        }

        private void UpdatePickDetail(TWhBin zoneBin, TOutPick pick, TOutPickD pickDetail)
        {
            if (pick.FirstScanAt == null)
                pick.FirstScanAt = DateTime.UtcNow;

            pick.LastScanAt = DateTime.UtcNow;

            pick.Qty += 1;

            pick.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            pickDetail.Qty = 1;
            pickDetail.ActZoneId = zoneBin.ZoneId;
            pickDetail.ActZoneCode = zoneBin.ZoneCode;
            pickDetail.ActBinId = zoneBin.Id;
            pickDetail.ActBinCode = zoneBin.Code;
            pickDetail.IsPicked = true;
            pickDetail.LastModifiedBy = DefaultUser.UserName;
            pickDetail.LastModifiedTime = DateTime.UtcNow;

            //更新出库单状态
            var outbound = wmsoutbound.TOuts.Where(x => x.Id == pick.OutboundId).FirstOrDefault();
            outbound.PickStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            wmsoutbound.SaveChanges();
        }

    }
}