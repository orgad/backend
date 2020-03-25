using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class RecheckService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();
        SkuService skuService = new SkuService();

        InventoryService inventoryService = new InventoryService();

        public List<TOutCheck> PageList()
        {
            return this.Query().ToList();
        }

        public IQueryable<TOutCheck> Query()
        {
            return wmsoutbound.TOutChecks as IQueryable<TOutCheck>;
        }

        public int TotalCount()
        {
            return this.Query().Count();
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

        public bool CreateByPicks(long[] pickIds)
        {
            var outPicks = wmsoutbound.TOutPicks.Where(x=>pickIds.Contains(x.Id)).ToList();
            foreach(var outPick in outPicks)
            {
                CreateByPick(outPick);
            }
            return true;
        }

        private void CreateByPick(TOutPick outPick)
        {
            var recheck = new TOutCheck
            {
                Code = outPick.Code.Replace("PCK", "RCK"),
                OutboundId = outPick.OutboundId,
                Status = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Init),
                Store = outPick.Store,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.Now,
            };

            outPick.Status = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Finished);

            var outbound = wmsoutbound.TOuts.Where(x=>x.Id == outPick.OutboundId).FirstOrDefault();
            outbound.PickStatus = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Finished);
            outbound.ScanStatus = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Init);

            wmsoutbound.TOutChecks.Add(recheck);

            wmsoutbound.SaveChanges();
        }

        public bool Scan(long recheckId, VScanRequest request)
        {
            var recheck = wmsoutbound.TOutChecks.Where(x => x.Id == recheckId).FirstOrDefault();
            if (recheck == null)
            {
                throw new Exception("pick is not exist.");
            }

            if (recheck.FirstScanAt == null)
                recheck.FirstScanAt = DateTime.UtcNow;

            recheck.LastScanAt = DateTime.UtcNow;
            recheck.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            //获取SKU信息
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);
            if (prodSku == null)
            {
                throw new Exception("barcode is not exist.");
            }

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

            //更新出库单状态
            var outbound = wmsoutbound.TOuts.Where(x => x.Id == recheckId).FirstOrDefault();
            outbound.ScanStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            wmsoutbound.TOutCheckDs.Add(recheckDetail);

            return wmsoutbound.SaveChanges() > 0;
        }

        internal bool Affirms(long[] ids)
        {
            //复核确认扣减库存
            foreach (var id in ids)
            {
                Affirm(id);
            }
            return true;
        }

        private bool Affirm(long recheckId)
        {
            //更新单据状态
            var recheck = wmsoutbound.TOutChecks.Where(x => x.Id == recheckId).FirstOrDefault();
            recheck.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
            
            var outbound = wmsoutbound.TOuts.Where(x => x.Id == recheck.OutboundId).FirstOrDefault();
            
            //按拣货情况来扣减库存
            
            var picks = (from pickD in wmsoutbound.TOutPickDs
                        join pick in wmsoutbound.TOutPicks on pickD.HId equals pick.Id
                        where pick.OutboundId == outbound.Id
                        select pickD)
                        .ToList();

            //扣减库存
            inventoryService.Delivery(outbound.WhId,picks);

            //更新出库状态
            outbound.ScanStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
            outbound.ActualAt = DateTime.UtcNow;
            outbound.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            return wmsoutbound.SaveChanges()>0;
        }
    }
}