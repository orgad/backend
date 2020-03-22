using System.Web.Http;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Services
{
    public class WaveMobileController : ApiController
    {
        WaveService waveService = new WaveService();

        [Route("{id}/advice")]
        [HttpGet]
        public JsonResult Advice([FromUri]long id)
        {
            var result = waveService.Advice(id);
            return new JsonResult(result);
        }

        [Route("{id}/scan")]
        [HttpPost]
        public JsonResult Scan([FromUri] long id, [FromBody]VScanBinRequest detail)
        {
            var result = waveService.Scan(id, detail);
            return new JsonResult(result);
        }
    }
}