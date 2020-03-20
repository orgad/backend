using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    public class ExpressService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        public List<TOutExpress> PageList()
        {
            return this.Query().ToList();
        }

        public IQueryable<TOutExpress> Query()
        {
            return wmsoutbound.TOutHandovers as IQueryable<TOutExpress>;
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        internal bool Create(TOutExpress express)
        {
            express.CreatedBy = DefaultUser.UserName;
            express.CreatedTime = DateTime.UtcNow;
            
            wmsoutbound.TOutExpresses.Add(express);
            return wmsoutbound.SaveChanges()>0;
        }
    }
}