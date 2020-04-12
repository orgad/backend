using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// authorization
// 授权
namespace dotnet_wms_ef.Auth.Controllers
{
    //用户
    [Route("api/get")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public string Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            var id = claimsIdentity.Claims.FirstOrDefault(c => c.Type == "ID").Value;

            return $"Hello! your ID is:{id}";
        }
    }
}