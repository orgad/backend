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

        internal bool Affirms(long[] ids)
        {
            //交接确认.更新交接状态
            foreach(var id in ids)
            {
                Affirm(id);
            }
            return true;
        }

        private bool Affirm(long id)
        {
            return true;
        }
    }
}