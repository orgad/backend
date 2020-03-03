using System.Web.Http;
using dotnet_wms_ef.Views.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/inbound/")]
    public class InboundController : ApiController
    {
        InboundService inboundService = new InboundService();
        
        /*列表信息*/
        [HttpGet]
        [Route("list")]
        [EnableCors("any")]
        public JsonResult List()
        {
            var list = inboundService.PageList();
            var totalCount = inboundService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }
        
        /*查看详情*/
        [HttpGet]
        [Route("details/{id}")]
        public VInbound Details(long id)
        {
            var vInbound = inboundService.Details(id);
            return vInbound;
        }

        [HttpGet]
        [Route("opt-list")]
        public JsonResult RcvOptList()
        {
            var r= inboundService.OptList();
            return new JsonResult(r);
        }
        
        [HttpGet]
        [Route("opt/{id}")]
        public JsonResult RcvOpt([FromUri] long id)
        {
            var r= inboundService.Opt(id);
            return new JsonResult(r);
        }

        /*收货确认*/
        [HttpPut]
        [Route("check")]
        public JsonResult Affirm([FromBody]long[] ids)
        { 
            var result = inboundService.RcvAffirm(ids);
            return new JsonResult(result);
        }
    }
}