using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using dotnet_wms_ef.Inbound.ViewModels;
using Microsoft.AspNetCore.Hosting;
using dotnet_wms_ef.ViewModels;
using dotnet_wms_ef.Inbound.Services;
using dotnet_wms_ef.Inbound.Models;
using System;

namespace dotnet_wms_ef.Inbound.Controllers
{
    [Route("/api/in/rn/")]
    [EnableCors("any")]
    public class RnController : ApiController
    {
        RnService rnService = new RnService();

        private readonly IWebHostEnvironment _webHostEnvironment;

        public RnController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            rnService.Root = _webHostEnvironment.WebRootPath;
        }

        [HttpGet]
        [Route("list")]
        public JsonResult List([FromUri]QueryRn queryRn)
        {
            var list = rnService.PageList(queryRn);
            var totalCount = rnService.TotalCount(queryRn);
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpPost]
        [Route("create")]
        public JsonResult Create([FromBody]VRnAddForm rnAddForm)
        {
            var result = rnService.Create(rnAddForm);

            return new JsonResult(result);
        }

        [HttpPost]
        [Route("{id}/create-detail")]
        public JsonResult CreateDetail([FromUri]long id,[FromBody]VRnDetailAddForm[] list)
        {
            var result = rnService.CreateDetail(id,list);

            return new JsonResult(result);
        }

        [HttpPost]
        [EnableCors("any")]
        [Route("importdetail")]
        public JsonResult Upload(IFormFile file, [FromUri]ImportRequest importRequest)
        {
            var r = rnService.Import(file, importRequest.id, importRequest.code);
            return new JsonResult(r);
        }
    }
}