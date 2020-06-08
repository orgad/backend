using System;
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
        NavService navService = new NavService();
        RoleService roleService = new RoleService();

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
            var roleNavIds = wmsauth.TPermRoleNavs.Where(x => x.RoleId == roleId).Select(x => x.NavId).ToList();
            var roleActionIds = wmsauth.TPermRoleNavs.Where(x => x.RoleId == roleId).Select(x => x.ActionId).ToList();

            var navs = wmsauth.TPermNavs.Where(x => roleNavIds.Contains(x.Id)).ToList();
            var actions = wmsauth.TPermNavActions
                           .Where(x => roleNavIds.Contains(x.NavId) && roleActionIds.Contains(x.Id)).ToList();

            foreach (var nav in navs)
            {
                var v = new VNavActionDetails();
                v.Nav = nav;
                v.DetailList = actions.Where(x => x.NavId == nav.Id).ToList();
                list.Add(v);
            }

            return list;
        }

        public bool Create(int roleId, int moduleId, VNavActionAdd[] vNavActions)
        {
            var navCodes = navService.NavList();
            var actionCodes = navService.ActionList();
            var roleCodes = roleService.RoleList();

            //查询当前数据库中的记录:只查询指定模块的内容
            var modules = navService.NavListByModuleId(moduleId).ToList();
            var navIds = modules.Select(x => x.Id).ToList();
            var olds = wmsauth.TPermRoleNavs.Where(x => x.RoleId == roleId && navIds.Contains(x.NavId)).ToList();

            //开始删除delete *********************************
            //处理需要删除的: vNavActions不存在的
            if (vNavActions == null || !vNavActions.Any())
            {
                //全部删除
                foreach (var old in olds)
                {
                    wmsauth.TPermRoleNavs.Remove(old);
                }
            }
            else
            {
                var deletes = new List<TPermRoleNav>();
                foreach (var old in olds)
                {
                    if (!vNavActions.Any(x => x.NavId == old.NavId && x.ActionId == old.ActionId))
                        wmsauth.TPermRoleNavs.Remove(old);
                }
            }

            //开始新增insert *********************************
            //处理需要新增的: olds中不存在的
            foreach (var navAction in vNavActions)
            {
                if (!olds.Any(x => x.NavId == navAction.NavId && x.ActionId == navAction.ActionId))
                {
                    var newItem = new TPermRoleNav
                    {
                        RoleId = roleId,
                        RoleCode = roleCodes.Where(x => x.Item1 == roleId).Select(x => x.Item2).FirstOrDefault(),
                        NavId = navAction.NavId,
                        NavCode = navCodes.Where(x => x.Item1 == navAction.NavId).Select(x => x.Item2).FirstOrDefault(),
                        ActionId = navAction.ActionId,
                        ActionCode = actionCodes.Where(x => x.Item1 == navAction.ActionId).Select(x => x.Item2).FirstOrDefault(),
                        CreatedBy = DefaultUser.UserName,
                        CreatedTime = DateTime.UtcNow
                    };
                    wmsauth.TPermRoleNavs.Add(newItem);
                }
            }

            //自动找到上级菜单,加入到数据库
            if (vNavActions!=null && vNavActions.Any())
            {
                var module = wmsauth.TPermRoleNavs.Where(x => x.NavId == moduleId && x.ActionId == null).FirstOrDefault();
                if (module == null)
                {
                    var newItem = new TPermRoleNav
                    {
                        RoleId = roleId,
                        RoleCode = roleCodes.Where(x => x.Item1 == roleId).Select(x => x.Item2).FirstOrDefault(),
                        NavId = moduleId,
                        NavCode = navCodes.Where(x => x.Item1 == moduleId).Select(x => x.Item2).FirstOrDefault(),
                        ActionId = null,
                        ActionCode = null,
                        CreatedBy = DefaultUser.UserName,
                        CreatedTime = DateTime.UtcNow
                    };
                    wmsauth.TPermRoleNavs.Add(newItem);
                }
            }

            return wmsauth.SaveChanges() > 0;
        }
    }
}