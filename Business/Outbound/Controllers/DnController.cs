using System.Web.Http;
using dotnet_wms_ef.Business.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/")]
    [EnableCors("any")]
    public class DnController : ApiController
    {
        DnService dnService = new DnService();
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
    }
}