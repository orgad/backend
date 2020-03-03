using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Views;
using dotnet_wms_ef.Views.ViewModels;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/asn/")]
    public class AsnController : ApiController
    {
        AsnService asnService = new AsnService();

        [HttpGet]
        [Route("list")]
        [EnableCors("any")]
        public JsonResult Index([FromUri]QueryAsn queryAsn)
        {
            var list = asnService.PageList(queryAsn);
            var totalCount = asnService.TotalCount(queryAsn);
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
        public VAsn Details(long id)
        {
            var vAsn = asnService.Details(id);
            return vAsn;
        }

        [HttpPost]
        [Route("full")]
        public JsonResult CreateFull([FromBody]VAsn vAsn)
        {
            var r = asnService.CreateFull(vAsn);
            var response = new JsonResult(r);
            return response;
        }

        [HttpPost]
        public JsonResult CreateAsn([FromBody]TInAsn tAsn)
        {
            var r = asnService.CreateAsn(tAsn);
            var response = new JsonResult(r);
            return response;
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("importdetail")] 
        public JsonResult Upload(IFormFile file,[FromUri]ImportRequest importRequest)
        {
            var r = asnService.Upload(file,importRequest.id,importRequest.code);
            return new JsonResult(r);
        }

        [HttpGet]
        [EnableCors("any")]
        [Route("details/download/{id}")]
        public IActionResult DownLoad(long id)
        {
            var r = asnService.DownLoad(id,id.ToString()); 
            return new PhysicalFileResult(r, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("affirm")]
        public JsonResult Do([FromBody] long[] ids)
        {
            var r = asnService.Affirm(ids);
           return new JsonResult(r);
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("check-affirm")]
        public JsonResult Check([FromBody] long[] ids)
        {
            var r = asnService.Check(ids);
           return new JsonResult(r);
        }
    }
}