using System.Web.Http;
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
        [Route("role-list")]
        public JsonResult RoleList()
        {
            var list = roleService.PagedList();
            var total = roleService.Total();
            return new JsonResult( new SingleResponse{
               TotalCount = total,
               Data = list
            });
        }

        [HttpGet]
        [Route("biz-list")]
        public JsonResult BizList()
        {
            var list = roleService.PagedBizList();
            var total = roleService.BizTotal();
            return new JsonResult( new SingleResponse{
               TotalCount = total,
               Data = list
            });
        }

        [HttpGet]
        [Route("{id}/role-list")]
        public JsonResult RolesByUserId([FromUri]int id)
        {
            var result = roleService.GetByRolesByUserId(id);
            return new JsonResult(result);
        }
    }
}