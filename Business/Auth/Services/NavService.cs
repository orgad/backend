using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotnet_wms_ef.Auth.Models;
using dotnet_wms_ef.Auth.ViewModels;

namespace dotnet_wms_ef.Auth.Services
{
    public class NavService
    {
        wmsauthContext wmsauth = new wmsauthContext();
        public ICollection<TPermNav> PagedList(VQueryNav query)
        {
            if (query.PageSize == 0)
                query.PageSize = 20;

            return this.Query(query)
                   .Skip(query.PageIndex * query.PageSize).Take(query.PageSize)
                   .ToList();
        }

        public int Total(VQueryNav query)
        {
            return this.Query(query).Count();
        }

        private IQueryable<TPermNav> Query(VQueryNav query)
        {
            return wmsauth.TPermNavs as IQueryable<TPermNav>;
        }

        public ICollection<TPermNavAction> PagedList(VQueryNavAction query)
        {
            if (query.PageSize == 0)
                query.PageSize = 20;

            return this.Query(query)
                   .Skip(query.PageIndex * query.PageSize).Take(query.PageSize)
                   .ToList();
        }

        public int Total(VQueryNavAction query)
        {
            return this.Query(query).Count();
        }

        private IQueryable<TPermNavAction> Query(VQueryNavAction query)
        {
            var q = wmsauth.TPermNavActions as IQueryable<TPermNavAction>;
            if (query.NavId > 0)
            {
                q = q.Where(x => x.NavId == query.NavId);
            }
            return q;
        }

        public VNavActionDetails Details(int navId)
        {
            var o = wmsauth.TPermNavs.Where(x => x.Id == navId).FirstOrDefault();
            var detailList = wmsauth.TPermNavActions.Where(x => x.NavId == navId).ToList();

            return new VNavActionDetails { Nav = o, DetailList = detailList };
        }
    }
}