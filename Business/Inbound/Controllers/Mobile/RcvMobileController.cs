using System;
using System.Web.Http;
using dotnet_wms_ef.Models;
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
                    data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpPost]
        [Route("scan/{id}")]
        public bool Scan([FromUri]long id, [FromBody] TInOptlog opt)
        {
            //新增扫描记录,同时增加收货明细
            opt.OrderId = id;
            try
            {
                rcvService.Create(opt);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}