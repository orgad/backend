using System.Web.Http;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Mobile.Controllers
{
    [Route("/api/mobile/out/pck/")]
    [EnableCors("any")]
    public class PickMobileController : ApiController
    {
        PickService pickService = new PickService();

        [Route("list")]
        [HttpGet]
        public JsonResult List(QueryPick queryPick)
        {
            return new JsonResult(new SingleResponse
            {
                TotalCount = pickService.TotalCount(queryPick),
                Data = pickService.PageList(queryPick)
            });
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri]long id)
        {
            var result = pickService.Details(id);
            return new JsonResult(result);
        }

        [Route("{id}/advice")]
        [HttpGet]
        public JsonResult Advice([FromUri]long id)
        {
            var result = pickService.Advice(id);
            return new JsonResult(result);
        }

        [Route("{id}/scan")]
        [HttpPost]
        public JsonResult Scan([FromUri] long id, [FromBody]VScanBinRequest detail)
        {
            var result = pickService.Scan(id, detail);
            return new JsonResult(result);
        }
    }
}