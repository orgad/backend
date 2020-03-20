using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/alot/")]
    [EnableCors("any")]
    public class AlotController : ApiController
    {
        AlotService alotService = new AlotService();

        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
            return new JsonResult(new SingleResponse
            {
                TotalCount = alotService.TotalCount(),
                Data = alotService.PageList()
            });
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri]long id)
        {
            var result = alotService.Details(id);
            return new JsonResult(result);
        }
    }
}