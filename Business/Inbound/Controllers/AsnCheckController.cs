using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/asn/check/")]
    [EnableCors("any")]
    public class AsnCheckController : ApiController
    {
        AsnCheckService asnCheckService = new AsnCheckService();

        [HttpGet]
        [Route("asn-check-list")]
        public JsonResult List([FromUri]QueryAsnCheck queryAsnCheck)
        {
            var list = asnCheckService.PageList(queryAsnCheck);
            var totalCount = asnCheckService.TotalCount(queryAsnCheck);
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpGet]
        [Route("{id}/details")]
        public VAsnCheckDetails Details(long id)
        {
            var vAsnCheck = asnCheckService.Details(id);
            return vAsnCheck;
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("check-affirm")]
        public JsonResult CheckConfirm([FromBody] long[] ids)
        {
            var r = asnCheckService.Checks(ids);
            return new JsonResult(r);
        }
    }
}