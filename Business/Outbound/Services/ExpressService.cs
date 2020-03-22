using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class ExpressService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        internal List<TOutExpress> PageList()
        {
            return this.Query().ToList();
        }

        internal IQueryable<TOutExpress> Query()
        {
            return wmsoutbound.TOutHandovers as IQueryable<TOutExpress>;
        }

        internal int TotalCount()
        {
            return this.Query().Count();
        }

        internal bool Create(TOutExpress express)
        {
            express.CreatedBy = DefaultUser.UserName;
            express.CreatedTime = DateTime.UtcNow;

            //更新出库单的面单号
            var outboundId = express.OutboundId;
            var outbound = wmsoutbound.TOuts.Where(x=>x.Id == outboundId).FirstOrDefault();
            outbound.ExpressNo = express.Code;
            
            wmsoutbound.TOutExpresses.Add(express);
            return wmsoutbound.SaveChanges()>0;
        }
    }
}