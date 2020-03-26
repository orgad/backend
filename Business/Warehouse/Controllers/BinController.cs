using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{

    [Route("/api/wh/bin/")]
    [EnableCors("any")]
    public class BinController : ApiController
    {
        BinService binService = new BinService();

        [HttpGet]
        [Route("list")]
        public JsonResult List()
        {
            var list = binService.PageList(20);
            var totalCount = binService.TotalCount();
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