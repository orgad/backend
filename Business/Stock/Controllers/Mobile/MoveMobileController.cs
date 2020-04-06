using System.Web.Http;
using dotnet_wms_ef.Stock.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/mobile/stock/move/")]
    [EnableCors("any")]
    public class MoveMobileController:ApiController
    {
        MoveMobileService mobileService = new MoveMobileService();

        [Route("task-list")]
        [HttpGet]
        public JsonResult List()
        {
            var result = mobileService.TaskPageList();
            var total = mobileService.TaskTotal();
            return new JsonResult(new SingleResponse{
                Data = result,
                TotalCount = total
            });
        }
    }
}