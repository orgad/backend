using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Auth.Models;
using dotnet_wms_ef.Auth.ViewModels;

namespace dotnet_wms_ef.Auth.Services
{
    // 返回某个角色的菜单和按钮权限
    public class RoleNavService
    {
        wmsauthContext wmsauth = new wmsauthContext();
        public List<VNav> RoleNavList()
        {
            var items = wmsauth.TPermNavs.ToList();
            return this.NavList(items);
        }

        public List<VNav> RoleNavList(int[] roleIds)
        {
            var navids = wmsauth.TPermRoleNavs
                         .Where(x => roleIds.Contains(x.RoleId)).Select(x => x.NavId).ToList();
            var items = wmsauth.TPermNavs
                        .Where(x => navids.Contains(x.Id)).ToList();

            return this.NavList(items);
        }

        public List<VNav> UserNavList(int[] userIds)
        {
            var roleIds = wmsauth.TPermUserRoles
                         .Where(x => userIds.Contains(x.UserId)).Select(x => x.RoleId).ToList();
            var navids = wmsauth.TPermRoleNavs
                         .Where(x => roleIds.Contains(x.RoleId)).Select(x => x.NavId)
                         .Distinct().ToList();
            var items = wmsauth.TPermNavs.Where(x => navids.Contains(x.Id)).ToList();

            return this.NavList(items);
        }

        private List<VNav> NavList(List<TPermNav> items)
        {
            var list = new List<VNav>();
            var parent = items.Where(x => string.IsNullOrEmpty(x.AllPath)).ToList();

            for (var i = 0; i < parent.Count; i++)
            {
                var nav = new VNav { Title = parent[i].NameCn };
                nav.Children = RoleChildList(parent[i].Code, items);
                list.Add(nav);
            }
            return list;
        }

        private ICollection<VNavSub> RoleChildList(string parentCode, List<TPermNav> items)
        {
            var list = new List<VNavSub>();
            var childs = items.Where(x => x.PCode == parentCode).ToList();
            foreach (var child in childs)
            {
                list.Add(new VNavSub { Title = child.NameCn, Router = child.AllPath });
            }
            return list;
        }

        public ICollection<VNavActionDetails> GetNavsByRoleId(int roleId)
        {
            var list = new List<VNavActionDetails>();
            var navIds = wmsauth.TPermRoleNavs.Where(x => x.RoleId == roleId).Select(x => x.NavId).ToList();

            var navs = wmsauth.TPermNavs.Where(x => navIds.Contains(x.Id)).ToList();
            var actions = wmsauth.TPermNavActions.Where(x => navIds.Contains(x.NavId)).ToList();

            foreach (var nav in navs)
            {
                var v = new VNavActionDetails();
                v.Nav = nav;
                v.DetailList = actions.Where(x => x.NavId == nav.Id).ToList();
                list.Add(v);
            }

            return list;

        }
    }
}