using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using Microsoft.AspNetCore.Http;

using dotnet_wms_ef.Models;
using dotnet_wms_ef.Views.ViewModels;


namespace dotnet_wms_ef.Services
{
    public class AsnCheckService
    {
        wmsinboundContext wms = new wmsinboundContext();

        public TInCheck Create(TInAsn asn)
        {
            var o = new TInCheck();
            o.HId = asn.Id;
            o.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
            o.IsCiq = asn.IsCiq;
            o.Code = asn.Code.Replace(Enum.GetName(typeof(EnumOrderType), EnumOrderType.ASN),
                   Enum.GetName(typeof(EnumOrderType), EnumOrderType.CHK));
            o.CreatedBy = DefaultUser.UserName;
            o.CreatedTime = DateTime.UtcNow;
            return o;
        }

        public TInCheck Get(long id)
        {
            return wms.TInChecks.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Update(long id, TInCheck check)
        {
            var o = wms.TInChecks.Where(x => x.Id == id).FirstOrDefault();
            if (o != null)
            {
                o.CartonQty = check.CartonQty;
                o.Qty = check.Qty;
                o.DamageCartonQty = check.DamageCartonQty;
                o.DamageQty = check.DamageQty;
                return wms.SaveChanges() > 0;
            }
            return false;
        }

        public int TotalCount(QueryAsnCheck queryAsnCheck)
        {
            return this.Query(queryAsnCheck).Count();
        }

        public List<TInCheck> List()
        {
            return wms.TInChecks.ToList();
        }

        public List<TInCheck> PageList(QueryAsnCheck queryAsnCheck)
        {
            return this.Query(queryAsnCheck).
            OrderByDescending(x => x.Id).Skip(queryAsnCheck.pageIndex).Take(queryAsnCheck.pageSize).ToList();
        }

        private IQueryable<TInCheck> Query(QueryAsnCheck queryAsnCheck)
        {
            if (queryAsnCheck.pageSize == 0)
                queryAsnCheck.pageSize = 20;

            var query = wms.TInChecks as IQueryable<TInCheck>;

            return query;
        }

        public VAsnCheck Details(long id)
        {
            var o = wms.TInChecks.Where(x => x.Id == id).FirstOrDefault();

            var ds = wms.TInCheckDs.Where(x => x.HId == id).ToList();

            return new VAsnCheck { AsnCheck = o, AsnCheckDs = ds.Any() ? ds.ToArray() : null };
        }

        public bool CreateDetails(long id, TInCheckD[] details)
        {
            foreach (var detail in details)
            {
                detail.HId = id;
                detail.CreatedBy = "rickli";
                detail.CreatedTime = DateTime.UtcNow;
            }
            wms.TInCheckDs.AddRange(details);

            return wms.SaveChanges() > 0;
        }
    }
}