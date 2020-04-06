using System.Web.Http;
using dotnet_wms_ef.Stock.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/stock/move/")]
    [EnableCors("any")]
    public class MoveController : ApiController
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

        [Route("create-plan")]
        [HttpPost]
        public JsonResult CreatePlan([FromBody]TInvtMovePlan vCheck)
        {
            return new JsonResult(true);
        }

        [Route("update-plan")]
        [HttpPut]
        public JsonResult UpdatePlan([FromUri]long id, [FromBody]TInvtMovePlan vPlan)
        {
            return new JsonResult(true);
        }

        [Route("create")]
        [HttpPost]
        public JsonResult Create([FromBody]TInvtMove vMove)
        {
            return new JsonResult(true);
        }

        [Route("update")]
        [HttpPut]
        public JsonResult Update([FromUri]long id, [FromBody]TInvtMove vMove)
        {
            return new JsonResult(true);
        }
    }
}