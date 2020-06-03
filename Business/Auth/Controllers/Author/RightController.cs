using System.Web.Http;
using dotnet_wms_ef.Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Auth.Controllers
{
    // 返回数据权限
    [Route("api/auth/right/")]
    public class RightController : ApiController
    {
        UserService userService = new UserService();
        RoleService roleService = new RoleService();
        RoleNavService roleNavService = new RoleNavService();
        UserRoleService userRoleService = new UserRoleService();

        [Route("{id}/role-nav-list")]
        public JsonResult RoleNavListByRole([FromUri] int id)
        {
            //按照角色获取菜单
            var result = roleNavService.RoleNavList();
            return new JsonResult(result);
        }

        [Route("{id}/nav-action-list-by-role")]
        public JsonResult NavActionListByRole([FromUri] int id)
        {
            //按照角色获取菜单和按钮
            var result = roleNavService.GetNavsByRoleId(id);
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{id}/user-list")]
        public JsonResult UsersByRoleId([FromUri] int id)
        {
            //按照角色获取用户列表
            var result = userService.GetUsersByRoleId(id);
            return new JsonResult(result);
        }

        [Route("{id}/user-nav-list")]
        public JsonResult RoleNavListByUserId([FromUri] int id)
        {
            //按照登录用户获取菜单
            var result = userRoleService.UserNavList(id);
            return new JsonResult(result);
        }

        [Route("{id}/login-nav-list")]
        public JsonResult RoleNavListByUserId([FromUri] string id)
        {
            //按照登录用户获取菜单
            var result = userRoleService.LoginNavList(id);
            return new JsonResult(result);
        }
        

        [HttpGet]
        [Route("{id}/biz-list")]
        public JsonResult BizsByUserId([FromUri] int id)
        {
            //按照登录用户获取业务约束
            var result = userService.GetUsersByRoleId(id);
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{id}/role-list")]
        public JsonResult RolesByUserId([FromUri] int id)
        {
            //按照登录用户获取角色列表
            var result = roleService.GetByRolesByUserId(id);
            return new JsonResult(result);
        }
    }
}