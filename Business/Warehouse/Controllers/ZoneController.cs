using System.Web.Http;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/wh/zone/")]
    [EnableCors("any")]
    public class ZoneController : ApiController
    {
        ZoneService zoneService = new ZoneService();

        [HttpGet]
        [Route("list")]
        public JsonResult List()
        {
           var list = zoneService.PageList(20);
            var totalCount = zoneService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }
    }
}