using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    internal class PutAwayService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();

        ProductService productService = new ProductService();

        ZoneService zoneService = new ZoneService();
        BinService binService = new BinService();

        InventoryService inventoryService = new InventoryService();

        public TInPutaway Create(TInQc qc)
        {
            var pt = new TInPutaway
            {
                Code = qc.Code.Replace("QC", "PTA"),
                InboundId = qc.InboundId,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };
            return pt;
        }

        public TInPutaway Create(TInInbound inbound)
        {
            var pt = new TInPutaway
            {
                Code = inbound.Code.Replace("RCV", "PTA"),
                WhId = inbound.WhId,
                InboundId = inbound.Id,
                Status = inbound.PStatus,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };
            return pt;
        }

        private IQueryable<TInPutaway> Query(QueryPutAway queryPutAway)
        {
            if (queryPutAway.PageSize == 0)
                queryPutAway.PageSize = 20;

            var query = wmsinbound.TInPutaways as IQueryable<TInPutaway>;
            if (!string.IsNullOrEmpty(queryPutAway.status))
            {
                query = query.Where(x => x.Status == queryPutAway.status);
            }
            return query;
        }

        public List<TInPutaway> PageList(QueryPutAway queryPutAway)
        {
            return this.Query(queryPutAway).
            OrderByDescending(x => x.Id).Skip(queryPutAway.PageIndex).Take(queryPutAway.PageSize).ToList();
        }

        public int TotalCount(QueryPutAway queryPutAway)
        {
            return this.Query(queryPutAway).Count();
        }

        public List<TInPutaway> PageTaskList(QueryPutAway queryPutAway)
        {
            if (queryPutAway.PageSize == 0)
                queryPutAway.PageSize = 20;

            return this.Query(queryPutAway).
            Where(
                x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init) ||
                x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing))
                .OrderByDescending(x => x.Id).Skip(queryPutAway.PageIndex).Take(queryPutAway.PageSize).ToList();
        }

        public int TotalTaskCount(QueryPutAway queryPutAway)
        {
            return this.Query(queryPutAway).
             Where(
                x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init) ||
                x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing))
            .Count();
        }

        public VPutAwayDetails Details(long id)
        {
            var o = wmsinbound.TInPutaways.Where(x => x.Id == id).FirstOrDefault();
            var detailList = wmsinbound.TInPutawayDs.Where(x => x.HId == id).ToArray();
            return new VPutAwayDetails { PutAway = o, PutAwayDs = detailList };
        }

        public Tuple<bool, string> Scan(long id, TInPutawayD detail)
        {
            //校验商品
            var prodSku = productService.GetSkuByBarcode(detail.Barcode);
            if (prodSku == null)
                return new Tuple<bool, string>(false, "barcode is not exist.");

            var pt = wmsinbound.TInPutaways.Where(x => x.Id == id).FirstOrDefault();
            //校验货位
            var bin = binService.GetBinByCode(pt.WhId, detail.BinCode);
            if (bin == null)
                return new Tuple<bool, string>(false, "binCode is not exist.");

            var zone = zoneService.GetZoneByCode(pt.WhId, bin.ZoneCode);

            //校验数量
            var qty = wmsinbound.TInPutawayDs.Where(x => x.HId == pt.Id && x.SkuId == prodSku.Id).Sum(x => x.Qty);

            var inboundQty = wmsinbound.TInInboundDs.Where(x => x.HId == pt.InboundId && x.SkuId == prodSku.Id)
            .Select(x => x.Qty).FirstOrDefault();

            var inbound = wmsinbound.TInInbounds.Where(x => x.Id == pt.InboundId).FirstOrDefault();

            if (qty + 1 <= inboundQty)
            {
                if (pt.FirstPutawayAt == null)
                    pt.FirstPutawayAt = DateTime.UtcNow;
                pt.LastPutawayAt = DateTime.UtcNow;

                pt.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
                detail.ZoneId = zone.Id;
                detail.ZoneCode = zone.Code;
                detail.BinId = bin.Id;
                detail.BinCode = bin.Code;
                detail.HId = id;
                detail.CreatedBy = DefaultUser.UserName;
                detail.CreatedTime = DateTime.UtcNow;
                detail.Qty = 1;

                inbound.PStatus = pt.Status;

                wmsinbound.TInPutawayDs.Add(detail);
                var r = wmsinbound.SaveChanges() > 0;
                return new Tuple<bool, string>(false, string.Format("{0}/{1}", qty + 1, inboundQty));
            }
            else
            {
                return new Tuple<bool, string>(true, string.Format("{0}/{1}", inboundQty, inboundQty));
            }
        }

        public bool Done(long id)
        {
            var pt = wmsinbound.TInPutaways.Where(x => x.Id == id).FirstOrDefault();
            pt.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Done);
            return wmsinbound.SaveChanges() > 0;
        }

        public Tuple<bool, string> Confirm(long id)
        {
            //更新状态
            var pt = wmsinbound.TInPutaways.Where(x => x.Id == id).FirstOrDefault();
            pt.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var inbound = wmsinbound.TInInbounds.Where(x => x.Id == pt.InboundId).FirstOrDefault();
            inbound.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Finished);
            inbound.PStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
            inbound.ActualInAt = DateTime.UtcNow;

            var details = wmsinbound.TInPutawayDs.Where(x => x.HId == id).ToList();

            inventoryService.PutAways(pt.WhId, details.ToArray());

            //更新库存
            var r = wmsinbound.SaveChanges() > 0;
            return new Tuple<bool, string>(r, "");
        }
    }
}