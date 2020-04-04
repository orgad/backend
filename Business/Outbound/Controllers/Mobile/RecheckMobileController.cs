using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/mobile/out/recheck/")]
    [EnableCors("any")]
    public class RecheckMobileController : ApiController
    {
        RecheckService recheckService = new RecheckService();

        [Route("list")]
        public JsonResult List()
        {
            var result = recheckService.PageList();
            var total = recheckService.TotalCount();
            return new JsonResult(new SingleResponse
            {
                TotalCount = total,
                Data = result,
            });
        }
        
        [Route("task-list")]
        public JsonResult TaskList()
        {
            var result = recheckService.TaskPageList();
            var total = recheckService.TaskTotalCount();
            return new JsonResult(new SingleResponse{
                TotalCount = total,
                Data = result,
            });
        }

        [Route("{id}/details")]
        public JsonResult Details([FromUri] long id)
        {
            var result = recheckService.Details(id);
            return new JsonResult(result);
        }

        [Route("{id}/scan")]
        [HttpPut]
        public JsonResult Scan([FromUri] long id, [FromBody]VScanRequest vScan)
        {
            var result = recheckService.Scan(id,vScan);
            return new JsonResult(result);
        }
    }
}