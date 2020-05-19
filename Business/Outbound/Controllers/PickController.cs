using System.Web.Http;
using dotnet_wms_ef.Outbound.Services;
using dotnet_wms_ef.Outbound.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Outbound.Controllers
{
    [Route("/api/out/pck/")]
    [EnableCors("any")]
    public class PickController : ApiController
    {
        PickService pickService = new PickService();
        RecheckService recheckService = new RecheckService();

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

        [Route("from-outbound/{id}")]
        public JsonResult GetPickByOutbound(long id)
        {
            var result = pickService.GetPickByOutbound(id);
            return new JsonResult(result);
        }

        [Route("affirm")]
        [HttpPut]
        public JsonResult Affirm([FromBody]long[] ids)
        {
            var result = recheckService.CreateRckByPicks(ids);
            return new JsonResult(result);
        }

        [Route("{id}/print")]
        [HttpGet]
        public JsonResult Print([FromUri] long id)
        {
            var result = pickService.PrintDataSource(id);
            return new JsonResult(result);
        }

        [Route("print")]
        [HttpPut]
        public JsonResult Prints([FromBody] long[] ids)
        {
            var result = pickService.PrintDataSource(ids);
            return new JsonResult(result);
        }
    }
}