using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Controllers;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class PickService
    {
        public wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        ProductService productService = new ProductService();

        BinService binService = new BinService();

        public void Use()
        {

        }

        public bool CreatePick(TOut tOut)
        {
            TOutPick tOutPick = new TOutPick
            {
                Code = tOut.Code.Replace("SHP", "PCK"),
                WhId = tOut.WhId,
                OutboundId = tOut.Id,
                Store = tOut.Store,
                Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init),
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };

            var alotDetailList = (from detail in wmsoutbound.TOutAlotDs
                                  join alot in wmsoutbound.TOutAlots on detail.HId equals alot.Id
                                  where alot.OutboundId == tOut.Id
                                  select detail)
                                 .ToList();

            var detaiList = tOut.DetailList;

            foreach (var detail in alotDetailList)
            {
                for (int i = 0; i < detail.Qty; i++)
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

        private IQueryable<TOutPick> Query(QueryPick queryPick)
        {
            if (queryPick.PageSize == 0)
                queryPick.PageSize = 20;

            var query = wmsoutbound.TOutPicks;
            return query;
        }

        public VPickDetails Details(long pickId)
        {
            var pick = wmsoutbound.TOutPicks.Where(x => x.Id == pickId).FirstOrDefault();
            var detailList = wmsoutbound.TOutPickDs.Where(x => x.HId == pickId).ToArray();

            return new VPickDetails { Pick = pick, DetailList = detailList };
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


        public bool Scan(long pickId, VScanBinRequest detail)
        {
            var pick = wmsoutbound.TOutPicks.Where(x => x.Id == pickId).FirstOrDefault();
            if (pick == null)
            {
                throw new Exception("pick is not exist.");
            }

            //获取SKU信息
            var prodSku = productService.GetSkuByBarcode(detail.Barcode);
            if (prodSku == null)
            {
                throw new Exception("barcode is not exist.");
            }

            //新增拣货明细
            var pickDetail = wmsoutbound.TOutPickDs.Where(x => x.HId == pickId && x.Barcode == detail.Barcode).FirstOrDefault();
            if (pickDetail == null)
            {
                pickDetail = new TOutPickD
                {
                    HId = pick.Id,
                };
            }

            if (pick.FirstScanAt == null)
                pick.FirstScanAt = DateTime.UtcNow;

            pick.LastScanAt = DateTime.UtcNow;

            pick.Qty += 1;

            pick.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            //获取货区货位信息
            var zoneBin = binService.GetBinByCode(pick.WhId, detail.BinCode);

            pickDetail.ActBinId = zoneBin.Id;
            pickDetail.ActBinCode = detail.BinCode;
            pickDetail.Qty = 1;
            pickDetail.ActZoneCode = zoneBin.ZoneCode;
            pickDetail.ActZoneId = zoneBin.ZoneId;
            pickDetail.IsPicked = true;
            pickDetail.LastModifiedBy = DefaultUser.UserName;
            pickDetail.LastModifiedTime = DateTime.UtcNow;

            if (pickDetail.Id == 0)
            {
                wmsoutbound.TOutPickDs.Add(pickDetail);
            }

            return wmsoutbound.SaveChanges() > 0;
        }

    }
}