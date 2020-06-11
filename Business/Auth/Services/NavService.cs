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

        public List<Tuple<int, string>> NavList()
        {
            var tuples = new List<Tuple<int, string>>();
            var list = wmsauth.TPermNavs.ToList();
            foreach (var item in list)
            {
                tuples.Add(new Tuple<int, string>(item.Id, item.Code));
            }
            return tuples;
        }

        public List<Tuple<int, string>> ActionList()
        {
            var tuples = new List<Tuple<int, string>>();
            var list = wmsauth.TPermNavActions.ToList();
            foreach (var item in list)
            {
                tuples.Add(new Tuple<int, string>(item.Id, item.Code));
            }
            return tuples;
        }

        public List<TPermNav> NavListByModuleId(int id)
        {
            var list = wmsauth.TPermNavs.Where(x => x.PId == id || x.Id == id).ToList();

            return list;
        }

        public List<VNavActionDetails> NavActionListByModule(int moduleId)
        {
            //返回一个集合
            var os = wmsauth.TPermNavs.Where(x => x.PId == moduleId || x.Id == moduleId).ToList();
            var detailLists = wmsauth.TPermNavActions.ToList();

            var list = new List<VNavActionDetails>();
            foreach (var o in os)
            {
                var detailList = detailLists.Where(x => x.NavId == o.Id).ToList();
                list.Add(new VNavActionDetails
                {
                    Nav = o,
                    DetailList = detailList
                });
            }
            return list;
        }

        public bool Create(VNavAdd vNav)
        {
            TPermNav tNav = new TPermNav
            {
                ClientNo = vNav.ClientNo,
                PId = vNav.PId,
                PCode = vNav.PCode,
                Code=vNav.Code,
                NameCn = vNav.NameCn,
                NameEn = vNav.NameEn, 
                Seq = vNav.Seq,
                AllPath = vNav.AllPath,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow
            };

            wmsauth.TPermNavs.Add(tNav);

            return wmsauth.SaveChanges() > 0;
        }

        public bool CreateAction(int navId, VNavActionAdd vAction)
        {
            TPermNavAction tAction = new TPermNavAction
            {
                NavId = vAction.NavId,
                NavCode = vAction.NavCode,
                Code = vAction.Code,
                Name = vAction.Name,
                Seq = vAction.Seq,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow
            };

            wmsauth.TPermNavActions.Add(tAction);

            return wmsauth.SaveChanges() > 0;
        }
    }
}