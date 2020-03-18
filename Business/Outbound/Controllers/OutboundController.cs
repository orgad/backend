using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/outbound/")]
    [EnableCors("any")]
    public class OutboundController : ApiController
    {
        OutboundService outboundService = new OutboundService();

         [Route("list")]
        public JsonResult List(QueryOut queryOut)
        {
            return new JsonResult(new SingleResponse
            {
                TotalCount = outboundService.TotalCount(queryOut),
                Data = outboundService.PageList(queryOut)
            });
        }

         [Route("{id}/details")]
        public JsonResult Details([FromUri] long id)
        {
            var r = outboundService.Details(id);
            return new JsonResult(r);
        }
    }
}