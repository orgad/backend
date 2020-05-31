using dotnet_wms_ef.Auth.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Auth.Controllers
{
    //角色
    [Route("/api/auth/role/")]
    [EnableCors("any")]
    public class RoleController
    {
        RoleService roleService = new RoleService();

        [HttpGet]
        [Route("list")]
        public JsonResult List()
        {
            var list = roleService.PagedList();
            var total = roleService.Total();
            return new JsonResult( new SingleResponse{
               TotalCount = total,
               Data = list
            });
        }
    }
}