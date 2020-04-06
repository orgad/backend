using System.Web.Http;
using dotnet_wms_ef.Stock.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Stock.Controllers
{
    [Route("/api/stock/freeze/")]
    [EnableCors("any")]
    public class FreezeController:ApiController
    {
        FreezeService freezeService = new FreezeService();
        
        [Route("list")]
        [HttpGet]
        public JsonResult List()
        {
            var result = freezeService.PageList();
            var total = freezeService.Total();
            return new JsonResult(new SingleResponse{
                Data = result,
                TotalCount = total
            });
        }

        [Route("{id}/details")]
        [HttpGet]
        public JsonResult Details([FromUri] long id)
        {
             var result = freezeService.Details(id);
            return new JsonResult(result);
        }
    }
}