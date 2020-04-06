using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using dotnet_wms_ef.ViewModels;
using dotnet_wms_ef.Inbound.Services;
using dotnet_wms_ef.Inbound.ViewModels;

namespace dotnet_wms_ef.Inbound.Controllers
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
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }
        
        /*查看详情*/
        [HttpGet]
        [Route("details/{id}")]
        [EnableCors("any")]
        public VInboundDetails Details(long id)
        {
            var vInbound = inboundService.Details(id);
            return vInbound;
        }

        [HttpGet]
        [Route("from-asn/{id}")]
        [EnableCors("any")]
        public JsonResult GetByAsn([FromUri]long id)
        {
            var vInbound = inboundService.GetByAsn(id);
            return new JsonResult(vInbound);
        }

        [HttpGet]
        [Route("rcv/list")]
        [EnableCors("any")]
        public JsonResult RcvList()
        {
            var r= inboundService.RcvList();
            return new JsonResult(new SingleResponse{ TotalCount = 0,Data = r});
        }

        /*收货确认*/
        [HttpPut]
        [EnableCors("any")]
        [Route("check")]
        public JsonResult Affirm([FromBody]long[] ids)
        { 
            var result = inboundService.RcvAffirm(ids);
            return new JsonResult(result);
        }

        [HttpPut]
        [EnableCors("any")]
        [Route("qc-check")]
        public JsonResult QcAffirm([FromBody]long[] ids)
        { 
            var result = inboundService.QcAffirm(ids);
            return new JsonResult(result);
        }

        [HttpPut]
        [EnableCors("any")]
        [Route("putaway-check")]
        public JsonResult PtAffirm([FromBody]long[] ids)
        { 
            var result = inboundService.PtAffirm(ids);
            return new JsonResult(result);
        }
    }
}