using System;
using System.Web.Http;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/mobile/in/inbound/rcv/")]
    public class RcvMobileController : ApiController
    {
        RcvService rcvService = new RcvService();

        [HttpGet]
        [Route("list")]
        [EnableCors("any")]
        //收货任务清单
        public JsonResult List()
        {
            var list = rcvService.PageList();
            var totalCount = rcvService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpPost]
        [Route("scan/{id}")]
        public JsonResult Scan([FromUri]long id, [FromBody] TInInboundRcv vRcv)
        {
            //新增扫描记录,同时增加收货明细
            vRcv.HId = id;
            try
            {
                var result = rcvService.CreateRcv(vRcv);
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
    }
}