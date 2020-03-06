using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    internal class PutAwayService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();

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
            OrderByDescending(x => x.Id).Skip(queryPutAway.pageIndex).Take(queryPutAway.pageSize).ToList();
        }

        public int TotalCount(QueryPutAway queryPutAway)
        {
            return this.Query(queryPutAway).Count();
        }

        public List<TInPutaway> PageTaskList(QueryPutAway queryPutAway)
        {
            if (queryPutAway.pageSize == 0)
                queryPutAway.pageSize = 20;
                
            return this.Query(queryPutAway).
            Where(
                x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init) ||
                x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing))
                .OrderByDescending(x => x.Id).Skip(queryPutAway.pageIndex).Take(queryPutAway.pageSize).ToList();
        }

        public int TotalTaskCount(QueryPutAway queryPutAway)
        {
            return this.Query(queryPutAway).
             Where(
                x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init) ||
                x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing))
            .Count();
        }

        public VPutAway Details(long id)
        {
            var o = wmsinbound.TInPutaways.Where(x => x.Id == id).FirstOrDefault();
            var detailList = wmsinbound.TInPutawayDs.Where(x => x.HId == id).ToArray();
            return new VPutAway { PutAway = o, PutAwayDs = detailList };
        }

        public bool Scan(long id, TInPutawayD detail)
        {
            var pt = wmsinbound.TInPutaways.Where(x => x.Id == id).FirstOrDefault();
            pt.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
            if (pt.FirstPutawayAt == null)
                pt.FirstPutawayAt = DateTime.UtcNow;
            pt.LastPutawayAt = DateTime.UtcNow;

            detail.HId = id;
            detail.CreatedBy = DefaultUser.UserName;
            detail.CreatedTime = DateTime.UtcNow;
            detail.Qty = 1;
            wmsinbound.TInPutawayDs.Add(detail);
            return wmsinbound.SaveChanges() > 0;
        }

        public bool Done(long id)
        {
            var pt = wmsinbound.TInPutaways.Where(x => x.Id == id).FirstOrDefault();
            pt.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Done);
            return wmsinbound.SaveChanges() > 0;
        }

        public bool Confirm(long id)
        {
            //更新状态
            var pt = wmsinbound.TInPutaways.Where(x => x.Id == id).FirstOrDefault();
            pt.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var inbound = wmsinbound.TInInbounds.Where(x => x.Id == pt.InboundId).FirstOrDefault();
            inbound.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Finished);
            inbound.PStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var details = wmsinbound.TInPutawayDs.Where(x => x.Id == id).ToList();

            inventoryService.PutAways(pt.WhId, details.ToArray());

            //更新库存
            return wmsinbound.SaveChanges() > 0;
        }
    }
}