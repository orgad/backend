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

        public void Create(TOutPick outPick)
        {
             var recheck = new TOutCheck{
                 Code = outPick.Code.Replace("PCK","RCK"),
                 Store = outPick.Store,
                 CreatedBy = DefaultUser.UserName,
                 CreatedTime = DateTime.Now,
             };

             wmsoutbound.TOutChecks.Add(recheck);

             wmsoutbound.SaveChanges();    
        }

        internal bool Affirms(long[] ids)
        {
            //复核确认扣减库存
            foreach(var id in ids)
            {

            }
            return true;
        }

        private bool Affirm(long id)
        {
            //更新单据状态
            //扣减库存
            //更新出库状态
            return true;
        }
    }
}