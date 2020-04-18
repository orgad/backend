using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using dotnet_wms_ef.ViewModels;
using dotnet_wms_ef.Inbound.Services;
using dotnet_wms_ef.Inbound.ViewModels;

namespace dotnet_wms_ef.Inbound.Controllers
{
    [Route("/api/in/qc/")]
    public class QcContrller : ApiController
    {
        QcService qcService = new QcService();
        //质检任务查询

        [Route("list")]
        [HttpGet]
        [EnableCors("any")]
        public JsonResult List(QueryQc queryQc)
        {
            return new JsonResult(
                new SingleResponse
                {
                    TotalCount = qcService.TotalCount(queryQc),
                    Data = qcService.PageList(queryQc)
                }
            );
        }

        [Route("{id}")]
        [HttpGet]
        [EnableCors("any")]
        public JsonResult Single([FromUri]long id)
        {
               var r = qcService.Get(id);

               return new JsonResult(r);
        }

        //质检详情
        [Route("{id}/details")]
        [HttpGet]
        [EnableCors("any")]
        public JsonResult Details([FromUri]long id)
        {
               var r = qcService.Details(id);

               return new JsonResult(r);
        }
        
        //质检确认
        [Route("confirm")]
        [EnableCors("any")]
        [HttpPut]
        public JsonResult Confirm([FromBody]long[] ids)
        {
            var r = qcService.Confirm(ids);
            return new JsonResult(r);
        }
    }
}