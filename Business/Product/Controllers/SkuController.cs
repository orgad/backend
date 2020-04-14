using System.Web.Http;
using dotnet_wms_ef.Product.Services;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/prod/sku/")]
    [EnableCors("any")]
    public class SkuController : ApiController
    {
        SkuService skuService = new SkuService();

        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = skuService.PageList(page);
            var totalCount = skuService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [Route("create")]
        [HttpPost]
        public JsonResult Create(VSkuAddForm sku)
        {
            var result = skuService.Create(sku);
            return new JsonResult(result);
        }
    }
}