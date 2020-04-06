using System.Web.Http;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.Services;
using dotnet_wms_ef.Stock.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/stock/check/")]
    [EnableCors("any")]
    public class StockCheckController:ApiController
    {
        StockCheckService service = new StockCheckService();
        
        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
            var result = service.PageList();
            var total = service.Total();
            return new JsonResult(new SingleResponse{
                Data = result,
                TotalCount = total,
            });
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri] long id)
        {
            var result = service.Details(id);
            return new JsonResult(result);
        }

        [Route("create")]
        [HttpPost]
        public JsonResult Create([FromBody]VCheckAddForm vCheck)
        {
            var result = service.Create(vCheck);
            return new JsonResult(result);
        }

        [Route("update")]
        [HttpPut]
        public JsonResult Update([FromUri]long id,[FromBody]TInvtCheck vCheck)
        {
            return new JsonResult(true);
        }

        [Route("audit")]
        [HttpPut]
        public JsonResult Audit([FromBody]long[] id)
        {
            return new JsonResult(true);
        }
    }
}