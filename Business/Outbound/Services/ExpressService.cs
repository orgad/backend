using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

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
            return wmsoutbound.TOutExpresses as IQueryable<TOutExpress>;
        }

        internal int TotalCount()
        {
            return this.Query().Count();
        }

        internal bool Create(VOutExpressRequest request)
        {
            var outbound = wmsoutbound.TOuts.Where(x=>x.Code == request.OutboundCode).FirstOrDefault();

            var express = new TOutExpress();
            express.OutboundId = outbound.Id;
            express.OutboundCode = request.OutboundCode;
            express.Courier = request.Courier.ToString();
            express.Code = request.Code;
            express.CreatedBy = DefaultUser.UserName;
            express.CreatedTime = DateTime.UtcNow;

            //更新出库单的面单号
            outbound.ExpressNo = express.Code;
            
            wmsoutbound.TOutExpresses.Add(express);
            return wmsoutbound.SaveChanges()>0;
        }
    }
}