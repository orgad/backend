using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.Inbound.ViewModels;
using dotnet_wms_ef.Services;

namespace dotnet_wms_ef.Inbound.Services
{
    public class RnService : BaseService
    {
        ExcelIOService ioService = new ExcelIOService();

        public string Root { get; set; }

        public RnService()
        {
            this.wms = new wmsinboundContext();
        }

        public List<TInRn> PageList(QueryRn queryRn)
        {
            return this.Query(queryRn).
            OrderByDescending(x => x.Id).Skip(queryRn.PageIndex).Take(queryRn.PageSize).ToList();
        }

        public int TotalCount(QueryRn queryRn)
        {
            return this.Query(queryRn).Count();
        }

        private IQueryable<TInRn> Query(QueryRn queryRn)
        {
            if (queryRn.PageSize == 0)
                queryRn.PageSize = 20;

            var query = wms.TInRns as IQueryable<TInRn>;
            return query;
        }

        public bool Create(VRnAddForm rnAddForm)
        {
            TInRn tRn = new TInRn();

            tRn.Code = "RN" + DateTime.Now.ToString(FormatString.DefaultFormat);
            tRn.BatchNo = rnAddForm.BatchNo ?? DateTime.Now.ToString("yyyyMMdd");
            tRn.WhId = rnAddForm.WhId;
            tRn.CustId = rnAddForm.CustId;
            tRn.BrandId = rnAddForm.BrandId;
            tRn.BizCode = rnAddForm.BizCode;
            tRn.TransCode = "Return";
            tRn.GoodsType = rnAddForm.GoodsType;
            tRn.TypeCode = "RN";
            tRn.Courier = rnAddForm.Courier;
            tRn.TrackingNo = rnAddForm.TrackingNo;
            tRn.SrcCode = "Import";
            tRn.CreatedBy = DefaultUser.UserName;
            tRn.CreatedTime = DateTime.UtcNow;
            tRn.Status = "None";

            wms.TInRns.Add(tRn);
            return wms.SaveChanges() > 0;
        }
    }
}