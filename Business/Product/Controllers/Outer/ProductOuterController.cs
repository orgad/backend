using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using dotnet_wms_ef.Product.Services;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Product.Outer.Controllers
{
    [Route("/api/outer/prod/")]
    [EnableCors("any")]
    public class ProductOuterController
    {
        ProductService productServive = new ProductService();

        [Route("product")]
        [HttpGet]
        public JsonResult List()
        {
            var result = productServive.OuterList();
            return new JsonResult(new SingleResponse
            {
                Data = result,
                TotalCount = result.Count
            });
        }
    }
}