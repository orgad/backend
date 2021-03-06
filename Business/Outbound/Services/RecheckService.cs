using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Outbound.Models;
using dotnet_wms_ef.Outbound.ViewModels;
using dotnet_wms_ef.Product.Services;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Outbound.Services
{
    public class RecheckService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();
        SkuService skuService = new SkuService();

        InventoryService inventoryService = new InventoryService();

        public List<TOutCheck> PageList()
        {
            return this.Query().OrderByDescending(x => x.Id).ToList();
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        public List<TOutCheck> TaskPageList()
        {
            return this.Query()
                       .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                              x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
                       .OrderByDescending(x => x.Id)
                       .ToList();
        }

        public int TaskTotalCount()
        {
            return this.Query()
                       .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                              x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
                       .Count();
        }

        public IQueryable<TOutCheck> Query()
        {
            return wmsoutbound.TOutChecks as IQueryable<TOutCheck>;
        }

        public VRecheckDetails Details(long id)
        {
            var recheck = wmsoutbound.TOutChecks.Where(x => x.Id == id).FirstOrDefault();
            var detailList = wmsoutbound.TOutCheckDs.Where(x => x.HId == id).ToList();
            return new VRecheckDetails
            {
                Recheck = recheck,
                DetailList = detailList
            };
        }

        public TOutCheck GetRecheckByOutbound(long outboundId)
        {
            var recheck = wmsoutbound.TOutChecks.Where(x => x.OutboundId == outboundId).FirstOrDefault();
            return recheck;
        }

        public List<Tuple<bool, long, string>> CreateRckByPicks(long[] pickIds)
        {
            var list = new List<Tuple<bool, long, string>>();
            var outPicks = wmsoutbound.TOutPicks
                           .Where(x => x.Status != Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished)
                                      && pickIds.Contains(x.Id))
                           .ToList();

            // 不能操作的直接返回
            foreach (var pickId in pickIds)
            {
                if (!outPicks.Any(x => x.Id == pickId))
                {
                    list.Add(new Tuple<bool, long, string>(false, pickId, ""));
                }
            }

            //剩余的可以继续操作
            foreach (var outPick in outPicks)
            {
                list.Add(CreateRckByPick(outPick));
            }
            return list;
        }

        private Tuple<bool, long, string> CreateRckByPick(TOutPick outPick)
        {
            var recheck = new TOutCheck
            {
                Code = outPick.Code.Replace("PCK", "RCK"),
                WhId = outPick.WhId,
                OutboundId = outPick.OutboundId,
                OutboundCode = outPick.OutboundCode,
                PickId = outPick.Id,
                PickCode = outPick.Code,
                Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init),
                Store = outPick.Store,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.Now,
            };

            outPick.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var outbound = wmsoutbound.TOuts.Where(x => x.Id == outPick.OutboundId).FirstOrDefault();
            outbound.PickStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
            outbound.ScanStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);

            wmsoutbound.TOutChecks.Add(recheck);

            var r1 = wmsoutbound.SaveChanges() > 0;

            return new Tuple<bool, long, string>(r1, outPick.Id, "");
        }

        public VOutScanResponse Scan(long recheckId, VScanRequest request)
        {
            VOutScanResponse response = new VOutScanResponse
            {
                AllFinished = false,
                Message = ""
            };
            var recheck = wmsoutbound.TOutChecks.Where(x => x.Id == recheckId).FirstOrDefault();
            if (recheck == null)
            {
                throw new Exception("pick is not exist.");
            }

            //获取SKU信息
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);
            if (prodSku == null)
            {
                throw new Exception("barcode is not exist.");
            }

            //校验复核的数量和出库单的数量
            var recheckQty = wmsoutbound.TOutCheckDs.Where(x => x.HId == recheckId && x.Barcode == request.Barcode).Sum(x => x.Qty);
            var skuQty = wmsoutbound.TOutDs.Where(x => x.HId == recheck.OutboundId && x.Barcode == request.Barcode).Sum(x => x.Qty);

            if (recheckQty < skuQty)
            {
                AddRecheckDetail(recheck, request);
                response.Message = string.Format("{0}/{1}", recheckQty + 1, skuQty);
            }
            else
            {
                response.AllFinished = true;
                response.Message = string.Format("{0}/{1}", recheckQty, skuQty);
            }
            return response;
        }

        private bool AddRecheckDetail(TOutCheck recheck, VScanRequest request)
        {
            var recheckId = recheck.Id;
            //新增复核明细
            var recheckDetail = new TOutCheckD
            {
                HId = recheckId,
                Qty = 1,
                Carton = request.Carton,
                Barcode = request.Barcode,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.Now,
            };

            if (recheck.FirstScanAt == null)
                recheck.FirstScanAt = DateTime.UtcNow;

            recheck.Qty += 1;

            recheck.LastScanAt = DateTime.UtcNow;
            recheck.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            //更新出库单状态
            var outbound = wmsoutbound.TOuts.Where(x => x.Id == recheckId).FirstOrDefault();
            outbound.ScanStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            wmsoutbound.TOutCheckDs.Add(recheckDetail);

            return wmsoutbound.SaveChanges() > 0;
        }

        internal List<Tuple<bool, long, string>> Affirms(long[] ids)
        {
            var list = new List<Tuple<bool, long, string>>();
            //某些状态不能操作
            var rechecks = wmsoutbound.TOutChecks
                           .Where(x => x.Status != Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished) &&
                                     ids.Contains(x.Id))
                           .ToList();

            foreach (var id in ids)
            {
                if (!rechecks.Any(x => x.Id == id))
                {
                    list.Add(new Tuple<bool, long, string>(false, id, ""));
                }
            }

            //复核确认扣减库存
            foreach (var id in ids)
            {
                list.Add(Affirm(id));
            }
            return list;
        }

        private Tuple<bool, long, string> Affirm(long recheckId)
        {
            //更新单据状态
            var recheck = wmsoutbound.TOutChecks.Where(x => x.Id == recheckId).FirstOrDefault();
            recheck.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var outbound = wmsoutbound.TOuts.Where(x => x.Id == recheck.OutboundId).FirstOrDefault();

            //按拣货情况来扣减库存(按SKU和库位分组)

            var picks = (from pickD in wmsoutbound.TOutPickDs
                         join pick in wmsoutbound.TOutPicks on pickD.HId equals pick.Id
                         where pick.OutboundId == outbound.Id
                         select pickD)
                        .ToList();
            //扣减库存
            inventoryService.Delivery(outbound.WhId, outbound.Id, outbound.CustId, outbound.Code, picks);

            //更新出库状态
            outbound.ScanStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
            outbound.ActualAt = DateTime.UtcNow;
            outbound.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var r1 = wmsoutbound.SaveChanges() > 0;

            return new Tuple<bool, long, string>(r1, recheckId, "");
        }
    }
}