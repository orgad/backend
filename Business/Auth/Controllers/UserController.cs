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
        public JsonResult Create([FromBody] VUserAdd user)
        {
            var result = userService.Create(user);
            return new JsonResult(result);
        }
    }
}