using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    // 前端用的查询功能
    public class OutStService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        public List<TOutSt> StList()
        {
            //出库策略主表
            return wmsoutbound.TSts.ToList();
        }

        private List<TOutStD> StDList()
        {
            //出库流程
            return wmsoutbound.TStDs.ToList();
        }

        public List<TOutStOpt> StOptList()
        {
            //出库流程选项
            return wmsoutbound.TStOpts.ToList();
        }

        public VOutStDetails Details(long id)
        {
            var st = wmsoutbound.TSts.Where(x => x.Id == id).FirstOrDefault();
            var stds = wmsoutbound.TStDs.Where(x => x.HId == id).ToList();
            var stalot = wmsoutbound.TStAllots.Where(x => x.HId == id).ToList();
            var stwave = wmsoutbound.TStWaves.Where(x => x.HId == id).ToList();
            var stpick = wmsoutbound.TStPicks.Where(x => x.HId == id).FirstOrDefault();
            var stdelivery = wmsoutbound.TStDelivery.Where(x => x.HId == id).FirstOrDefault();

            return new VOutStDetails
            {
                TOutSt = st,
                TOutStDs = stds.ToArray(),
                TOutStAlots = stalot.ToArray(),
                TOutStDelivery = stdelivery,
                TOutStWaves = stwave.ToArray(),
                TOutStPick = stpick,
            };
        }
    }
}