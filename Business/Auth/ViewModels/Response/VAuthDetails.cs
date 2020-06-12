using System.Collections.Generic;

namespace dotnet_wms_ef.Auth.ViewModels
{
    public class VAuthDetails
    {
        /*用户信息,含角色*/
        public UserInfo UserInfo { get; set; }
        /*菜单权限*/
        public ICollection<VNav> vNavs { get; set; }
        /*业务权限*/
        public ICollection<VBiz> vBizs { get; set; }
    }

    public class UserInfo
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public ICollection<RoleInfo> RoleInfos { get; set; }
    }

    public class RoleInfo
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}