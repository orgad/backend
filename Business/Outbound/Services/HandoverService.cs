using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class HandoverService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        public List<TOutHandover> PageList()
        {
            return this.Query().ToList();
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        public List<TOutHandover> TaskPageList()
        {
            return this.Query()
                   .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                   x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.None))
            .ToList();
        }

        public int TaskTotalCount()
        {
            return this.Query()
                   .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                   x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.None))
            .Count();
        }

        private IQueryable<TOutHandover> Query()
        {
            return wmsoutbound.TOutHandovers.OrderByDescending(x => x.Id)
                   as IQueryable<TOutHandover>;
        }

        public VHandoverDetails Details(long id)
        {
            var handover = wmsoutbound.TOutHandovers.Where(x => x.Id == id).FirstOrDefault();
            var detailList = wmsoutbound.TOutHandoverDs.Where(x => x.HId == id).ToList();
            return new VHandoverDetails
            {
                Handover = handover,
                DetailList = detailList
            };
        }

        public bool Create(VHandOverRequest request)
        {
            TOutHandover handover = new TOutHandover();
            handover.Code = "HOV" + DateTime.Now.ToString(FormatString.DefaultFormat);
            handover.WhId = request.WhId;
            handover.CustId = request.CustId;
            handover.Store = request.Store.ToString();
            handover.CreatedBy = DefaultUser.UserName;
            handover.CreatedTime = DateTime.UtcNow;
            handover.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.None);

            wmsoutbound.TOutHandovers.Add(handover);

            return wmsoutbound.SaveChanges() > 0;
        }

        public bool Scan(long handoverId, VScanExpressRequest vExpress)
        {
            //首先查找条码是否存在
            var express = wmsoutbound.TOutExpresses.Where(x => x.Code == vExpress.ExpressCode).FirstOrDefault();
            if (express == null)
            {
                throw new Exception("couriercode is not exists.");
            }

            var detail = new TOutHandoverD
            {
                HId = handoverId,
                Courier = vExpress.CourierCode,
                ExpressNo = vExpress.ExpressCode,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };

            var handOver = wmsoutbound.TOutHandovers.Where(x => x.Id == handoverId).FirstOrDefault();
            handOver.Qty += 1;
            handOver.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            if (handOver.FirstScanAt == null)
                handOver.FirstScanAt = DateTime.UtcNow;

            handOver.LastScanAt = DateTime.UtcNow;

            wmsoutbound.TOutHandoverDs.Add(detail);
            return wmsoutbound.SaveChanges() > 0;
        }

        internal List<Tuple<bool, long, string>> Affirms(long[] ids)
        {
            var list = new List<Tuple<bool, long, string>>();

            var handOvers = wmsoutbound.TOutHandovers
                          .Where(x => x.Status != Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished)
                             && ids.Contains(x.Id)).ToList();

            foreach (var id in ids)
            {
                if (!handOvers.Any(x => x.Id == id))
                {
                    list.Add(new Tuple<bool, long, string>(false, id, ""));
                }
            }

            //交接确认.更新交接状态
            foreach (var id in ids)
            {
                list.Add(Affirm(id));
            }
            return list;
        }

        private Tuple<bool, long, string> Affirm(long hanoverId)
        {
            //根据交接单id找到交接单明细
            var handOver = wmsoutbound.TOutHandovers.Where(x => x.Id == hanoverId).FirstOrDefault();
            handOver.ShippedDate = DateTime.UtcNow;
            handOver.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);

            var detailList = wmsoutbound.TOutHandoverDs.Where(x => x.HId == hanoverId).ToList();
            //根据快递面单找到出库单
            var expressNos = detailList.Select(x => x.ExpressNo).ToList();
            var outbounds = wmsoutbound.TOuts.Where(x => expressNos.Contains(x.ExpressNo)).ToList();
            foreach (var outbound in outbounds)
            {
                outbound.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
                outbound.HandoverStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Finished);
            }
            try
            {
                var r1 = wmsoutbound.SaveChanges() > 0;

                return new Tuple<bool, long, string>(r1, hanoverId, "");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, long, string>(false, hanoverId, ex.Message);
            }
        }
    }
}