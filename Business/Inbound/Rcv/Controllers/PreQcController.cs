using System.Web.Http;
using dotnet_wms_ef.Inbound.Services;
using dotnet_wms_ef.Inbound.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Inbound.Controllers
{
    [Route("/api/in/pre-qc/")]
    [EnableCors("any")]
    public class PreQcController : ApiController
    {
        PreQcService qcService = new PreQcService();

        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
            var result = new SingleResponse{
                TotalCount = qcService.TotalCount(),
                Data = qcService.PageList()
            };
            return new JsonResult(result);
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri]long id)
        {
            var result = qcService.Details(id);
            return new JsonResult(result);
        }

        [Route("{id}/create-detail-list")]
        [HttpPost]
        public JsonResult CreateDetailList([FromUri]long id, [FromBody] VPreQcDetail[] list)
        {
            var result = qcService.CreateDetailList(id,list);
            return new JsonResult(result);
        }

        [Route("{id}/confirm")]
        [HttpPut]
        public JsonResult Confirm([FromBody]long[] ids)
        {
            var result = qcService.Confirm(ids);
            return new JsonResult(result);
        }
    }
}