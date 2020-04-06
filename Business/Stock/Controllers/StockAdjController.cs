using System.Web.Http;
using dotnet_wms_ef.Stock.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/stock/adj/")]
    [EnableCors("any")]
    public class StockAdjController : ApiController
    {
        StockAdjService adjService = new StockAdjService();

        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
            var result = adjService.PageList();
            var total = adjService.Total();
            return new JsonResult(new SingleResponse
            {
                Data = result,
                TotalCount = total
            });
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri] long id)
        {
            var result = adjService.Details(id);
            return new JsonResult(result);
        }
    }
}