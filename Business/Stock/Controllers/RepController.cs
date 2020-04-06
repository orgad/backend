using System.Web.Http;
using dotnet_wms_ef.Stock.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/stock/rep/")]
    [EnableCors("any")]
    public class RepController : ApiController
    {
        RepService repService = new RepService();

        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
            var result = repService.PageList();
            var total = repService.Total();
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
            return new JsonResult(true);
        }
    }
}