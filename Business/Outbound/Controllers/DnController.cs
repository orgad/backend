using System.Web.Http;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using dotnet_wms_ef.Views;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/dn/")]
    [EnableCors("any")]
    public class DnController : ApiController
    {
        DnService dnService = new DnService();

        private readonly IWebHostEnvironment _webHostEnvironment;

        public DnController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            dnService.Root = _webHostEnvironment.WebRootPath;
        }

        DnDetailService dnDetailService = new DnDetailService();

        [Route("list")]
        [HttpGet]
        public JsonResult List(QueryDn queryDn)
        {
            return new JsonResult(new SingleResponse
            {
                TotalCount = dnService.TotalCount(queryDn),
                Data = dnService.PageList(queryDn)
            });
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri]long id)
        {
            var result = dnService.Details(id);
            return new JsonResult(result);
        }

        [Route("{id}/detail-list")]
        [HttpGet]
        public JsonResult DetailList([FromUri]long id,QueryDn queryDn)
        {
            return new JsonResult(new SingleResponse
            {
                TotalCount = dnDetailService.TotalCount(queryDn,id),
                Data = dnDetailService.PageList(queryDn,id)
            });
        }

        [HttpPost]
        public JsonResult Create([FromBody] TOutDn dn)
        {
            if(dn==null)
            {
                return new JsonResult("dn is null.");
            }
            var result = dnService.Create(dn);
            return new JsonResult(result);
        }

        [Route("affirm")]
        [HttpPut]
        public JsonResult Audit([FromBody] long[] ids)
        {
            var result = dnService.Audit(ids);
            return  new JsonResult(result);
        }

        [Route("importdetail")]
        [HttpPost]
        public JsonResult Upload(IFormFile file, [FromUri]ImportRequest importRequest)
        {
            var r = dnService.Upload(file, importRequest.id, importRequest.code);
            return new JsonResult(r);
        }
    }
}