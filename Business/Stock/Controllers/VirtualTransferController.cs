using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/stock/virtual-transfer/")]
    [EnableCors("any")]
    public class VirtualTransferController:ApiController
    {
        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
            return new JsonResult(true);
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri] long id)
        {
            return new JsonResult(true);
        }
    }
}