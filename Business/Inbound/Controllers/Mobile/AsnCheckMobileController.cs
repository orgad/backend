using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using Microsoft.AspNetCore.Hosting;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/mobile/in/asn/check/")]
    public class AsnCheckMobileController : ApiController
    {
        AsnCheckService asnCheckService = new AsnCheckService();

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AsnCheckMobileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            asnCheckService.Root = _webHostEnvironment.WebRootPath;
        }

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
        [Route("{id}")]
        [EnableCors("any")]
        public JsonResult Get([FromUri]long id)
        {
            var single = asnCheckService.Get(id);
            var response = new JsonResult(single);
            return response;
        }

        [HttpPut]
        [EnableCors("any")]
        [Route("update/{id}")]
        public JsonResult Update([FromUri] long id, [FromBody] TInCheck asnCheck)
        {
            if (asnCheck == null) return new JsonResult("asnCheck is null.");
            var result = asnCheckService.Update(id, asnCheck);
            var response = new JsonResult(result);
            return response;
        }

        [HttpGet]
        [EnableCors("any")]
        [Route("{id}/detail-list")]
        public JsonResult DetailList([FromUri] long id,string barcode)
        {
            var result = asnCheckService.Details(id,barcode);
            var response = new JsonResult(result);
            return response;
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("{id}/detail-list-create")]
        public JsonResult CreateDetails([FromUri] long id, [FromBody] TInCheckD[] details)
        {
            var result = asnCheckService.CreateDetails(id, details);
            var response = new JsonResult(result);
            return response;
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("{id}/detail-upload")]
        public JsonResult UploadDetail([FromUri] long id, string fileDesc, IFormFile file)
        {
            if (file == null)
            {
                //
                return new JsonResult(false);
            }
            return new JsonResult(id + "\r\n" + fileDesc);
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("{id}/detail-list-upload")]
        public JsonResult UploadDetails([FromUri] long id, string barcode, IFormFileCollection files)
        {
            if (files == null || files.Count == 0)
            {
                return new JsonResult(false);
            }
            asnCheckService.UploadsAndCreateDetail(id, barcode, files);
            return new JsonResult(id + "\r\n" + barcode + "\r\n" + files.Count);
        }
    }
}