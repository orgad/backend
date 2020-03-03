using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Views;
using dotnet_wms_ef.Views.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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