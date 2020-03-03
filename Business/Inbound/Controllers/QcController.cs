using System.Web.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/qc/")]
    public class QcContrller : ApiController
    {
        QcService qcService = new QcService();
        //质检任务查询

        [Route("list")]
        [HttpGet]
        public JsonResult List(QueryQc queryQc)
        {
            return new JsonResult(
                new SingleResponse
                {
                    TotalCount = qcService.TotalCount(queryQc),
                    data = qcService.PageList(queryQc)
                }
            );
        }

        //质检详情
        [Route("details/{id}")]
        [HttpGet]
        public JsonResult Details([FromUri]long id)
        {
               var r = qcService.Details(id);

               return new JsonResult(r);
        }
        
        //质检确认
        [Route("confirm")]
        [HttpPut]
        public JsonResult Confirm([FromBody]long[] ids)
        {
            var r = qcService.Confirm(ids);
            return new JsonResult(r);
        }
    }
}