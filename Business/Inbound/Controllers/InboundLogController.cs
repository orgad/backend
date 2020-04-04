using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using dotnet_wms_ef.ViewModels;
using dotnet_wms_ef.Services;


namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/inbound/logs/")]
    [EnableCors("any")]
    public class InboundLogController : ApiController
    {
        
        InboundLogService inboundLogService = new InboundLogService();

        [Route("opt/list")]
        [HttpGet]
        public JsonResult OptList()
        {
            var r = inboundLogService.OptList();
            return new JsonResult(new SingleResponse { TotalCount = 0, Data = r });
        }
    }
}