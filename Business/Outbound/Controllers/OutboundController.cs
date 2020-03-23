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
        WaveService waveService = new WaveService();

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

        [Route("alot")]
        [HttpPut]
        public JsonResult Alot([FromBody] long[] ids)
        {
            var r = outboundService.Alots(ids);
            return new JsonResult(r);
        }

        [Route("wave")]
        [HttpPut]
        public JsonResult Wave([FromBody] long[] outboundIds)
        {
            var r = waveService.CreateWave(outboundIds);
            return new JsonResult(r);
        }

        [Route("pick")]
        [HttpPut]
        public JsonResult Pick([FromBody] long[] ids)
        {
            var r = outboundService.Picks(ids);
            return new JsonResult(r);
        }
    }
}