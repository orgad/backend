using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/cust/shop/")]
    [EnableCors("any")]
    public class ShopController : ApiController
    {
        ShopService shopService = new ShopService();
        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = shopService.PageList(page);
            var totalCount = shopService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }
    }
}