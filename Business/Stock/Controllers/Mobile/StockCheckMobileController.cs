using System.Web.Http;
using dotnet_wms_ef.Stock.Services;
using dotnet_wms_ef.Stock.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/mobile/stock/check/")]
    [EnableCors("any")]
    public class StockCheckMobileController:ApiController
    {
        StockCheckService service = new StockCheckService();

        [Route("task-list")]
        [HttpGet]
        public JsonResult List()
        {
            var result = service.TaskPageList();
            var total = service.TaskTotal();
            return new JsonResult(new SingleResponse{
                Data = result,
                TotalCount = total,
            });
        }

        [Route("{id}/scan")]
        [HttpPost]
        public JsonResult Scan([FromUri]long id,[FromBody]VCheckScan request)
        {
            var result = service.Scan(id,request);
            return new JsonResult(result);
        }
    }
}