using System.Web.Http;
using dotnet_wms_ef.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/putaway/")]
    public class PutAwayController : ApiController
    {
        PutAwayService putAwayService = new PutAwayService();

        //上架单查询
        [HttpGet]
        [Route("list")]
        [EnableCors("any")]
        public JsonResult List([FromUri]QueryPutAway queryPutAway)
        {
            return new JsonResult(new SingleResponse
            {
                data = putAwayService.PageList(queryPutAway),
                TotalCount = putAwayService.TotalCount(queryPutAway),
            });
        }

        [HttpGet]
        [Route("{id}/details")]
        [EnableCors("any")]
        //上架详情
        public JsonResult Details([FromUri]long id)
        {
            var result = putAwayService.Details(id);
            return new JsonResult(result);
        }


        [HttpPut]
        [Route("confirm")]
        [EnableCors("any")]
        //上架确认
        public JsonResult Confirm([FromBody]long id)
        {
            var result = putAwayService.Confirm(id);
            return new JsonResult(result);
        }
    }
}