using System.Web.Http;
using dotnet_wms_ef.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/in/st/")]
    [EnableCors("any")]
    public class InStController:ApiController
    {
        StService stService = new StService();
        //1.显示入库流程的基础数据
        [HttpGet]
        public JsonResult StOptList()
        {
            var result = stService.StOptList();
            return new JsonResult(result);
        }

        //2.展示入库流程
        [HttpGet]
        [Route("list")]
        public JsonResult StList()
        {
            var result = stService.StList();
            return new JsonResult(result);
        }
        
        [HttpGet]
        [Route("{id}/details")]
        public JsonResult St([FromUri] int id)
        {
            var result = stService.St(id);
            return new JsonResult(result);
        }

        //3.展示收货策略
        //4.展示上架策略
    }
}