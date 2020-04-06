using System.Web.Http;
using dotnet_wms_ef.Outbound.Services;
using dotnet_wms_ef.Outbound.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Mobile.Outbound.Controllers
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
                Data = pickService.PageList(queryPick),
                TotalCount = pickService.TotalCount(queryPick)
            });
        }

        [Route("task-list")]
        [HttpGet]
        public JsonResult TaskList(QueryPick queryPick)
        {
            return new JsonResult(new SingleResponse
            {
                Data = pickService.TaskPageList(queryPick),
                TotalCount = pickService.TaskTotalCount(queryPick)
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