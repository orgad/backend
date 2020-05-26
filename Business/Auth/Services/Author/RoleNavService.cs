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
            var list = new List<VNav>();

            var items = wmsauth.TPermNavs.ToList();

            var parent = items.Where(x => string.IsNullOrEmpty(x.AllPath)).ToList();

            for (var i = 0; i < parent.Count; i++)
            {
                var nav = new VNav { Title = parent[i].NameCn };
                nav.Children = RoleChildList(parent[i].Code,items);
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
    }
}