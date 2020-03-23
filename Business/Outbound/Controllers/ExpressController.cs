using System.Web.Http;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/express")]
    [EnableCors("any")]
    public class ExpressController : ApiController
    {
        ExpressService expressService = new ExpressService();

        [Route("list")]
        public JsonResult List()
        {
            var result = expressService.PageList();
            var total = expressService.TotalCount();
            return new JsonResult(new SingleResponse
            {
                TotalCount = total,
                Data = result,
            });
        }

        [Route("create")]
        [HttpPost]
        public JsonResult Create([FromBody] VOutExpressRequest express)
        {
            var result = expressService.Create(express);
            return new JsonResult(result);
        }
    }
}