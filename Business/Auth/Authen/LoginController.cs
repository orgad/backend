using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace dotnet_wms_ef
{
    public class LoginController : ApiController
    {
         //用户登录,token生成
         public JsonResult Login()
         {
             return new JsonResult(true);
         }
    }
}