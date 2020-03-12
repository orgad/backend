using System.Web.Http;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/mobile/in/putaway/")]
    public class PutAwayMobileController : ApiController
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
                TotalCount = putAwayService.TotalTaskCount(queryPutAway),
                Data = putAwayService.PageTaskList(queryPutAway)
            });
        }

        //上架任务详情
        [HttpGet]
        [Route("{id}/details")]
        [EnableCors("any")]
        public JsonResult Details([FromUri]long id)
        {
            var result = putAwayService.Details(id);
            return new JsonResult(result);
        }

        //上架任务查询
        [HttpGet]
        [Route("tasklist")]
        [EnableCors("any")]
        public JsonResult TaskList(QueryPutAway queryPutAway)
        {
            putAwayService.PageTaskList(queryPutAway);
            return new JsonResult(true);
        }

        //上架扫描
        [HttpPost]
        [Route("{id}/scan")]
        [EnableCors("any")]
        public JsonResult Scan([FromUri]long id,[FromBody] TInPutawayD d)
        {
             var result = putAwayService.Scan(id,d);
            return new JsonResult(new VScanResponse{
                IsAllFinished = result.Item1,
                Message = result.Item2
            });
        }

        //上架扫描完成
        [HttpPut]
        [Route("done")]
        [EnableCors("any")]
        public JsonResult Done(long id)
        {
            var result = putAwayService.Done(id);
            return new JsonResult(true);
        }
    }
}