using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public partial class StService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();

        public List<TStOpt> StOptList()
        {
            return wmsinbound.TStOpts.ToList();
        }

        public List<TSt> StList()
        {
            return wmsinbound.TSts.ToList();
        }

        public TSt StDetail(int whId, int custId, int brandId)
        {
            return wmsinbound.TSts.Where(x => x.WhId == whId && x.CustId == custId && x.BrandId == brandId)
            .FirstOrDefault();
        }

        public VInSt St(int id)
        {
            var r = new VInSt();
            var o = wmsinbound.TSts.Where(x => x.Id == id).FirstOrDefault();
            var d = StDList(id);
            var rcv = StRcv(id);
            var pa = StPutAway(id);
            if (pa != null)
            {
                var pad = StPutAwayDList(pa.Id);
                pa.Details = pad.ToArray();
            }
            r.TSt = o;
            r.TStDs = d;
            r.TStRcv = rcv;
            r.TStPutAway = pa;

            return r;
        }

        public List<TStD> StDList(int stId)
        {
            return wmsinbound.TStDs.Where(x => x.HId == stId).ToList();
        }

        public TStRcv StRcv(int stId)
        {
            return wmsinbound.TStRcvs.Where(x => x.HId == stId).FirstOrDefault();
        }

        public TStPutaway StPutAway(int stId)
        {
            return wmsinbound.TStPutaways.Where(x => x.Id == stId).FirstOrDefault();
        }

        public List<TStPutawayD> StPutAwayDList(int putAwayId)
        {
            return wmsinbound.TStPutawayDs.Where(x => x.HId == putAwayId).ToList();
        }
    }
}