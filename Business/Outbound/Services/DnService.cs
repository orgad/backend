using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Business.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class DnService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        OutboundService outboundService = new OutboundService();

        public Tuple<bool, string> Create(TOutDn dn)
        {
            dn.Code = "DN" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (string.IsNullOrEmpty(dn.BatchNo))
            {
                dn.BatchNo = DateTime.Now.ToString("yyyyMMdd");
            }
            dn.TypeCode = "SHP";
            dn.TransCode = "Outbound";
            dn.SrcCode = "Interface";
            dn.Status = "None";
            dn.IsDeleted = false;

            dn.CreatedBy = DefaultUser.UserName;
            dn.CreatedTime = DateTime.UtcNow;

            var result = wmsoutbound.SaveChanges() > 0;
            return new Tuple<bool, string>(result, "");
        }

        public List<TOutDn> PageList(QueryDn queryDn)
        {
            return this.Query(queryDn).ToList();
        }

        public int TotalCount(QueryDn queryDn)
        {
            return this.Query(queryDn).Count();
        }

        private IQueryable<TOutDn> Query(QueryDn queryDn)
        {
            var query = wmsoutbound.TOutDns;
            return query;
        }

        public VDnDetails Details(long dnId)
        {
            var dn = wmsoutbound.TOutDns.Where(x => x.Id == dnId).FirstOrDefault();
            var detailList = wmsoutbound.TOutDnDs.Where(x => x.HId == dnId).ToArray();

            return new VDnDetails { Dn = dn, DetailList = detailList };
        }

        public bool Audit(long[] ids)
        {
            var dns = wmsoutbound.TOutDns.Where(x => x.Status == "None" && ids.Contains(x.Id)).ToList();
            foreach (var dn in dns)
            {
                outboundService.CreateOutFromDn(dn);
            }
            return true;
        }
    }
}