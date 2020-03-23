using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/handover")]
    [EnableCors("any")]
    public class HandoverController:ApiController
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

        [Route("{id}/details")]
        public JsonResult Details([FromUri] long id)
        {
            var result = handoverService.Details(id);
            return new JsonResult(result);
        }

         [Route("create")]
         public JsonResult Create([FromBody] VHandOverRequest handOver)
        {
            var result = handoverService.Create(handOver);
            return new JsonResult(result);
        }

        [Route("affirm")]
        [HttpPut]
        public JsonResult Affirm([FromBody] long[] ids)
        {
            var result = handoverService.Affirms(ids);
            return new JsonResult(result);
        }
    }
}