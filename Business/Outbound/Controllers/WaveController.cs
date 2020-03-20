using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/out/wave/")]
    [EnableCors("any")]
    public class WaveController : ApiController
    {
        WaveService waveService = new WaveService();

        [Route("list")]
        public JsonResult List()
        {
            var result = waveService.PageList();
            var total = waveService.TotalCount();
            return new JsonResult(new SingleResponse{
                TotalCount = total,
                Data = result,
            });
        }

        [Route("{id}/details")]
        public JsonResult Details([FromUri] long id)
        {
            var result = waveService.Details(id);
            return new JsonResult(result);
        }

        [Route("affirm")]
        [HttpPut]
        public JsonResult Affirm([FromBody] long[] ids)
        {
            var result = waveService.Affirms(ids);
            return new JsonResult(result);
        }
    }
}