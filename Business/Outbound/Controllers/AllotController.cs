using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using dotnet_wms_ef.ViewModels;
using dotnet_wms_ef.Outbound.Services;

namespace dotnet_wms_ef.Outbound.Controllers
{
    [Route("/api/out/allot/")]
    [EnableCors("any")]
    public class AllotController : ApiController
    {
        AllotService allotService = new AllotService();

        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
            return new JsonResult(new SingleResponse
            {
                TotalCount = allotService.TotalCount(),
                Data = allotService.PageList()
            });
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri]long id)
        {
            var result = allotService.Details(id);
            return new JsonResult(result);
        }
    }
}