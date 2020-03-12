using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    //用来在移动端查询入库单
    [Route("/api/mobile/in/inbound/")]
    public class InboundMobileController :ApiController
    {
        InboundService inboundService = new InboundService();

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
    }
}