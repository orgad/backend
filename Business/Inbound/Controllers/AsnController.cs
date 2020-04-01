using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Views;
using dotnet_wms_ef.Views.ViewModels;
using Microsoft.AspNetCore.Hosting;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/asn/")]
    [EnableCors("any")]
    public class AsnController : ApiController
    {
        AsnService asnService = new AsnService();

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AsnController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            asnService.Root = _webHostEnvironment.WebRootPath;
        }

        [HttpGet]
        [Route("list")]
        public JsonResult Index([FromUri]QueryAsn queryAsn)
        {
            var list = asnService.PageList(queryAsn);
            var totalCount = asnService.TotalCount(queryAsn);
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
        [Route("details/{id}")]
        public VAsnDetails Details(long id)
        {
            var vAsn = asnService.Details(id);
            return vAsn;
        }

        [HttpPost]
        [Route("full")]
        public JsonResult CreateFull([FromBody]VAsnDetails vAsn)
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

        [HttpPut]
        public JsonResult UpdateAsn([FromBody]TInAsn vAsn)
        {
            var r = asnService.UpdateAsn(vAsn);
            var response = new JsonResult(r);
            return response;
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("importdetail")]
        public JsonResult Upload(IFormFile file, [FromUri]ImportRequest importRequest)
        {
            var r = asnService.Upload(file, importRequest.id, importRequest.code);
            return new JsonResult(r);
        }

        [HttpGet]
        [EnableCors("any")]
        [Route("details/download/{id}")]
        public IActionResult DownLoad(long id)
        {
            var r = asnService.DownLoad(id, id.ToString());
            return new PhysicalFileResult(r, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [HttpPut]
        [Route("affirm")]
        public JsonResult AsnConfirm([FromBody] long[] ids)
        {
            var r = asnService.Affirms(ids);
            return new JsonResult(r);
        }

        [HttpPut]
        [Route("check-affirm")]
        public JsonResult CheckConfirm([FromBody] long[] ids)
        {
            var r = asnService.Checks(ids);
            return new JsonResult(r);
        }
    }
}