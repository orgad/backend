using dotnet_wms_ef.Auth.Services;
using dotnet_wms_ef.Auth.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Auth.Controllers
{
    // 菜单,按钮
    [Route("/api/auth/nav/")]
    [EnableCors("any")]
    public class NavController
    {
        RoleNavService roleNavService = new RoleNavService();

        [Route("role-list")]
        public JsonResult RoleNavList()
        {
            //从token中获取用户信息
            
            var result = roleNavService.RoleNavList();
            return new JsonResult(result);
        }
    }
}