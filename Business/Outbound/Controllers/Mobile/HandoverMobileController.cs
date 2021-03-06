using System.Web.Http;
using dotnet_wms_ef.Outbound.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Mobile.Outbound.Controllers
{
    [Route("/api/mobile/out/handover/")]
    [EnableCors("any")]
    public class HandOverMobileController:ApiController
    {
        HandoverService handoverService = new HandoverService();

        [Route("list")]
        public JsonResult List()
        {
            var result = handoverService.PageList();
            var total = handoverService.TotalCount();
            return new JsonResult(new SingleResponse{
                TotalCount = total,
                Data = result,
            });
        }

        [Route("task-list")]
        public JsonResult TaskList()
        {
            var result = handoverService.TaskPageList();
            var total = handoverService.TaskTotalCount();
            return new JsonResult(new SingleResponse{
                TotalCount = total,
                Data = result,
            });
        }

        [Route("{id}/details")]
        public JsonResult Details([FromUri] long id)
        {
            var result = handoverService.Details(id);
            return new JsonResult(result);
        }

        
        [Route("{id}/scan")]
        [HttpPost]
        public JsonResult Scan([FromUri] long id,[FromBody]VScanExpressRequest request)
        {
            var result = handoverService.Scan(id,request);
            return new JsonResult(result);
        }

        [Route("affirm")]
        [HttpPut]
        public JsonResult Affirm([FromBody]long[] ids)
        {
            var result = handoverService.Affirms(ids);
            return new JsonResult(result);
        }
    }
}