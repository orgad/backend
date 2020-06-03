using System.Collections.Generic;
using dotnet_wms_ef.Auth.ViewModels;

namespace dotnet_wms_ef.Auth.Services
{
    //返回某个用户的菜单,数据权限
    public class UserRoleService
    {
        UserService userService = new UserService();
        RoleNavService roleNavService = new RoleNavService();
        public List<VNav> UserNavList(int userId)
        {
            return roleNavService.UserNavList(new[] { userId });
        }

        public List<VNav> LoginNavList(string loginName)
        {
            var userId = userService.getUserIdByLoginName(loginName);
            return roleNavService.UserNavList(new[] { userId });
        }
    }
}