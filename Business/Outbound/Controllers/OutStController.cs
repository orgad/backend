using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/st/")]
    [EnableCors("any")]
    public class OutStController : ApiController
    {
        OutStService outStService = new OutStService();
        //1.显示入库流程的基础数据
        [HttpGet]
        public JsonResult StOptList()
        {
            var result = outStService.StOptList();
            return new JsonResult(result);
        }

        [HttpGet]
        [Route("list")]
        public JsonResult StList()
        {
            var result = outStService.StList();
            return new JsonResult(new SingleResponse
            {
                TotalCount = 20,
                Data = result,
            });
        }

        [HttpGet]
        [Route("{id}/details")]
        public JsonResult Details([FromUri] long id)
        {
            var result = outStService.Details(id);
            return new JsonResult(result);
        }
    }
}