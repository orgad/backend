using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using dotnet_wms_ef.Inbound.Services;
using dotnet_wms_ef.ViewModels;
using dotnet_wms_ef.Inbound.ViewModels;

namespace dotnet_wms_ef.Inbound.Controllers
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
        [Route("from-asn/{id}")]
        public VAsnCheck GetByAsnId([FromUri]long id)
        {
            var vAsnCheck = asnCheckService.GetByAsnId(id);
            return vAsnCheck;
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