using System;
using System.Web.Http;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/mobile/in/qc/")]
    [EnableCors("any")]
    public class QcMobileController : ApiController
    {
        QcService qcService = new QcService();
        //质检单查询

        //质检任务详情
        [Route("list")]
        [HttpGet]
        public JsonResult List(QueryQc queryQc)
        {
            var r = new SingleResponse
            {
                TotalCount = qcService.TotalCount(queryQc),
                Data = qcService.PageList(queryQc),
            };
            return new JsonResult(r);
        }

        //质检任务查询
        //质检扫描
        [Route("{id}/scan")]
        [HttpPost]
        public JsonResult Scan([FromUri] long id, [FromBody]TInQcD qcD)
        {
            try
            {
                var result = qcService.Scan(id, qcD);
                return new JsonResult(new VScanResponse
                {
                    IsAllFinished = result.Item1,
                    Message = result.Item2
                });
            }
            catch (Exception ex)
            {
                var r = new ErrorResponse { ApiPath = "", Message = ex.Message };
                return new JsonResult(r);
            }
        }

        //质检拍照

        //质检扫描完成
        public JsonResult Finished([FromUri]long id)
        {
            qcService.Done(id);
            return new JsonResult(true);
        }
    }
}