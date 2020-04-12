using System.Web.Http;
using dotnet_wms_ef.Auth.Services;
using dotnet_wms_ef.Auth.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Auth.Controllers
{
    [Route("api/auth/user/")]
    public class UserController:ApiController
    {
        UserService userService = new UserService();

        [HttpPost]
        public JsonResult Create([FromBody]VUser user)
        {
            var result = userService.Create(user);
            return new JsonResult(result);
        }
    }
}