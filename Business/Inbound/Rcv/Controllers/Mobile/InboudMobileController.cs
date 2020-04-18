using System.Web.Http;
using dotnet_wms_ef.Inbound.Services;
using dotnet_wms_ef.Inbound.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Inbound.Controllers
{
    //用来在移动端查询入库单
    [Route("/api/mobile/in/inbound/")]
    public class InboundMobileController :ApiController
    {
        InboundService inboundService = new InboundService();

        [HttpGet]
        [Route("list")]
        [EnableCors("any")]

        public JsonResult List(QueryInbound query)
        {
            var list = inboundService.PageList(query);
            var totalCount = inboundService.TotalCount(query);
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }
    }
}