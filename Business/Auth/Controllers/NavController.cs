using System.Web.Http;
using dotnet_wms_ef.Auth.Services;
using dotnet_wms_ef.Auth.ViewModels;
using dotnet_wms_ef.ViewModels;
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
        NavService navService = new NavService();

        [Route("role-list")]
        public JsonResult RoleNavList()
        {
            //从token中获取用户信息

            var result = roleNavService.RoleNavList();
            return new JsonResult(result);
        }

        [Route("list")]
        public JsonResult NavList(VQueryNav query)
        {
            var list = navService.PagedList(query);
            var total = navService.Total(query);
            return new JsonResult(new SingleResponse
            {
                TotalCount = total,
                Data = list
            });
        }

        [Route("{id}/nav-action-list")]
        public JsonResult NavActionList([FromUri] int id)
        {
            var result = this.navService.Details(id);
            return new JsonResult(result);
        }
    }
}