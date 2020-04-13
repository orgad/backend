using dotnet_wms_ef.Auth.Services;
using dotnet_wms_ef.Auth.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

// authentication 认证
// authorization 授权
namespace dotnet_wms_ef.Auth.Controllers
{
    [Route("api/auth/login")]
    public class LoginController : ApiController
    {
         //用户登录,成功返回token,失败返回授权错误
         //然后使用token获取权限内容
         LoginService loginService = new LoginService();
         public JsonResult Login([FromBody] VUser user)
         {
             var result = loginService.Auth(user);
             return new JsonResult(result);
         }
    }
}