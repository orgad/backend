using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Outbound.Models;
using dotnet_wms_ef.Outbound.ViewModels;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Outbound.Services
{
    public class ExpressService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        CourierService courierService = new CourierService();

        internal List<TOutExpress> PageList()
        {
            return this.Query().ToList();
        }

        internal IQueryable<TOutExpress> Query()
        {
            return wmsoutbound.TOutExpresses.OrderByDescending(x => x.Id)
                   as IQueryable<TOutExpress>;
        }

        internal int TotalCount()
        {
            return this.Query().Count();
        }

        internal List<Tuple<bool, long, string>> CreateByOutboundId(long[] outboundIds)
        {
            var list = new List<Tuple<bool, long, string>>();
            var outbounds = wmsoutbound.TOuts.Where(x => outboundIds.Contains(x.Id)).ToList();
            foreach (var outbound in outbounds)
            {
                var express = new TOutExpress();
                express.OutboundId = outbound.Id;
                express.OutboundCode = outbound.Code;
                express.Courier = courierService.GetDefaultCourier();
                express.Code = outbound.Code.Substring(11, 9);
                express.CreatedBy = DefaultUser.UserName;
                express.CreatedTime = DateTime.UtcNow;

                //更新出库单的面单号
                outbound.ExpressNo = express.Code;

                wmsoutbound.TOutExpresses.Add(express);
                var r = wmsoutbound.SaveChanges() > 0;
                list.Add(new Tuple<bool, long, string>(r, express.Id, express.Code));
            }

            return list;
        }

        internal bool Create(VOutExpressRequest request)
        {
            var outbound = wmsoutbound.TOuts.Where(x => x.Code == request.OutboundCode).FirstOrDefault();

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
            return wmsoutbound.SaveChanges() > 0;
        }
    }
}