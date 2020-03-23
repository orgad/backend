using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/pck/")]
    [EnableCors("any")]
    public class PickController : ApiController
    {
         PickService pickService = new PickService();

         RecheckService recheckService = new RecheckService();

         [Route("list")]
        [HttpGet]
        public JsonResult List(QueryPick queryPick)
        {
            return new JsonResult(new SingleResponse
            {
                TotalCount = pickService.TotalCount(queryPick),
                Data = pickService.PageList(queryPick)
            });
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri]long id)
        {
            var result = pickService.Details(id);
            return new JsonResult(result);
        }

        [Route("affirm")]
        [HttpPost]
        public JsonResult Affirm([FromBody]long[] ids)
        {
            var result = recheckService.CreateByPicks(ids);
            return new JsonResult(result);
        }
    }
}