using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Auth.ViewModels;
using dotnet_wms_ef.Auth.Models;
using System;

namespace dotnet_wms_ef.Auth.Services
{
    //返回某个用户的菜单,数据权限
    public class UserRoleService
    {
        UserService userService = new UserService();
        RoleService roleService = new RoleService();
        RoleNavService roleNavService = new RoleNavService();
        wmsauthContext wmsauth = new wmsauthContext();
        public List<VNav> UserNavList(int userId)
        {
            return roleNavService.UserNavList(new[] { userId });
        }

        public List<VNav> LoginNavList(string loginName)
        {
            var userId = userService.getUserIdByLoginName(loginName);
            return roleNavService.UserNavList(new[] { userId });
        }

        public UserInfo GetUserInfo(string loginName)
        {
            //首先查询一下用户
            var user = userService.getUserByLoginName(loginName);
            //然后擦好像一下角色
            UserInfo userInfo = new UserInfo
            {
                UserId = user.Id,
                LoginName = user.LoginName,
            };

            var roles = wmsauth.TPermUserRoles.Where(x => x.UserId == user.Id).Select(x => new
            {
                x.RoleId,
                x.RoleCode
            }).ToList();

            userInfo.RoleInfos = new HashSet<RoleInfo>();

            foreach (var item in roles)
            {
                userInfo.RoleInfos.Add(new RoleInfo { RoleId = item.RoleId, RoleName = item.RoleCode });
            }

            return userInfo;
        }

        public bool Create(int userId, TPermRole[] roles)
        {
            //首先找到已经存在的roles,比对传入roles
            //如果已存在的不包括传入的,删除
            var datas = wmsauth.TPermUserRoles.Where(x => x.UserId == userId).ToList();
            var userCode = userService.getUserLoginNameById(userId);
            //如果传入的不属于已存在的,新增
            var oldRoles = roleService.GetByRolesByUserId(userId);

            //首先取交集合
            var items = oldRoles.Where(x => roles.Select(x => x.Id).Contains(x.Id)).Select(y => y.Id).ToList();
            //找到需要删除的:old-roles存在,roles不存在
            var needDeletds = oldRoles.Where(x => !items.Contains(x.Id)).ToList();
            foreach (var item in needDeletds)
            {
                var data = datas.Where(x => x.RoleId == item.Id).FirstOrDefault();
                if (data != null)
                    wmsauth.TPermUserRoles.Remove(data);
            }
            var needAdds = roles.Where(x => !items.Contains(x.Id)).ToList();
            foreach (var item in needAdds)
            {
                var data = new TPermUserRole
                {
                    UserId = userId,
                    LoginName = userCode,
                    RoleId = item.Id,
                    RoleCode = item.Code,
                    CreatedTime = DateTime.UtcNow,
                    CreatedBy = DefaultUser.UserName,
                };
                wmsauth.TPermUserRoles.Add(data);
            }

            return wmsauth.SaveChanges() > 0;
        }
    }
}