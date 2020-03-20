using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class WaveService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        public List<TOutWave> PageList()
        {
            return this.Query().ToList();
        }

        public IQueryable<TOutWave> Query()
        {
            return wmsoutbound.TOutChecks as IQueryable<TOutWave>;
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        public VWaveDetails Details(long id)
        {
            var wave = wmsoutbound.TOutWaves.Where(x => x.Id == id).FirstOrDefault();
            var detailList = wmsoutbound.TOutPicks.Where(x => x.WaveId == id).ToList();
            return new VWaveDetails
            {
                Wave = wave,
                DetailList = detailList
            };
        }

        internal bool Affirms(long[] ids)
        {
            foreach(var id in ids)
            {
               //批量生成复核单
               Affirm(id);
            }
            return true;
        }

        private void Affirm(long id)
        {

        }
    }
}