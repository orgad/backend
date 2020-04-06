using System.Web.Http;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.Services;
using dotnet_wms_ef.Stock.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/stock/move/")]
    [EnableCors("any")]
    public class MoveController : ApiController
    {
        MoveService moveService = new MoveService();
        
        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
           var result = moveService.PageList();
            var total = moveService.Total();
            return new JsonResult(new SingleResponse{
                Data = result,
                TotalCount = total
            });
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
        public JsonResult Create([FromBody]VMoveAddForm vMove)
        {
            var result = moveService.Create(vMove);
            return new JsonResult(result);
        }

        [Route("update")]
        [HttpPut]
        public JsonResult Update([FromUri]long id, [FromBody]TInvtMove vMove)
        {
            return new JsonResult(true);
        }
    }
}