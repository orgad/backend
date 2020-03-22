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

        public IQueryable<TOutHandover> Query()
        {
            return wmsoutbound.TOutHandovers as IQueryable<TOutHandover>;
        }

        public int TotalCount()
        {
            return this.Query().Count();
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

        public void Create(TOutHandover handover)
        {
            handover.Code = "HOV" + DateTime.Now.ToString("yyyyMMddHHmmsss");
            handover.Store = handover.Store;
            handover.CreatedBy = DefaultUser.UserName;
            handover.CreatedTime = DateTime.Now;

            wmsoutbound.TOutHandovers.Add(handover);

            wmsoutbound.SaveChanges();
        }

        public bool Scan(long handoverId, VScanExpressRequest vExpress)
        {
            var detail = new TOutHandoverD{
                HId = handoverId,
                Courier = vExpress.CourierCode,
                ExpressNo = vExpress.ExpressNo,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };

            var handOver = wmsoutbound.TOutHandovers.Where(x=>x.Id == handoverId).FirstOrDefault();
            handOver.Status = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Doing);
            
            wmsoutbound.TOutHandoverDs.Add(detail);
            return wmsoutbound.SaveChanges()>0;
        }

        internal bool Affirms(long[] ids)
        {
            //交接确认.更新交接状态
            foreach(var id in ids)
            {
                Affirm(id);
            }
            return true;
        }

        private bool Affirm(long hanoverId)
        {
            //根据交接单id找到交接单明细
            var handOver = wmsoutbound.TOutHandovers.Where(x=>x.Id == hanoverId).FirstOrDefault();
            handOver.ShippedDate = DateTime.UtcNow;
            handOver.Status = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Finished);
            
            var detailList = wmsoutbound.TOutHandoverDs.Where(x=>x.HId == hanoverId).ToList();
            //根据快递面单找到出库单
            var expressNos = detailList.Select(x=>x.ExpressNo).ToList();
            var outbounds = wmsoutbound.TOuts.Where(x=>expressNos.Contains(x.ExpressNo)).ToList();
            foreach(var outbound in outbounds)
            {
                outbound.Status = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Finished);
                outbound.HandoverStatus = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Finished);
            }
            return wmsoutbound.SaveChanges()>0;
        }
    }
}