using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using dotnet_wms_ef.Services;
using dotnet_wms_ef.Views.ViewModels;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/asn/check/")]
    public class AsnCheckController : ApiController
    {
        AsnCheckService asnCheckService = new AsnCheckService();

        [HttpGet]
        [Route("asn-check-list")]
        [EnableCors("any")]
        public JsonResult List([FromUri]QueryAsnCheck queryAsnCheck)
        {
            var list = asnCheckService.PageList(queryAsnCheck);
            var totalCount = asnCheckService.TotalCount(queryAsnCheck);
            var response = new JsonResult(
                new SingleResponse
                {
                    data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpGet]
        [Route("details/{id}")]
        public VAsnCheck Details(long id)
        {
            var vAsnCheck = asnCheckService.Details(id);
            return vAsnCheck;
        }
    }
}