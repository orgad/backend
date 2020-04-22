using System.Web.Http;
using dotnet_wms_ef.Product.ViewModels;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/prod/product/")]
    [EnableCors("any")]
    public class ProductController : ApiController
    {
        ProductService productService = new ProductService();

        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = productService.PageList(page);
            var totalCount = productService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list,
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpPost]
        [Route("add")]
        public JsonResult Create([FromBody]VProdAddForm prod)
        {
            var result = productService.Create(prod);
            return new JsonResult(result);
        }
    }
}