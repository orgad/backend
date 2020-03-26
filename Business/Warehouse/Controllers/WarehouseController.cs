using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/wh/warehouse/")]
    [EnableCors("any")]
    public class WarehouseController : ApiController
    {
        WhService WhService = new WhService();

        [HttpGet]
        [Route("list")]
        public JsonResult List()
        {
            var list = WhService.PageList(20);
            var totalCount = WhService.TotalCount();
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