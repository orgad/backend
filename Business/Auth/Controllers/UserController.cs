using System.Web.Http;
using dotnet_wms_ef.Auth.Services;
using dotnet_wms_ef.Auth.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Auth.Controllers
{
    [Route("api/auth/user/")]
    public class UserController : ApiController
    {
        UserService userService = new UserService();

        [HttpGet]
        [Route("list")]
        public JsonResult List()
        {
            var list = userService.PagedList();
            var total = userService.Total();
            return new JsonResult(new SingleResponse
            {
                TotalCount = total,
                Data = list
            });
        }

        [HttpPost]
        [Route("create")]
        public JsonResult Create([FromBody] VLogin user)
        {
            var result = userService.Create(user);
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("{id}/user-list")]
        public JsonResult UsersByRoleId([FromUri] int id)
        {
            var result = userService.GetUsersByRoleId(id);
            return new JsonResult(result);
        }
    }
}