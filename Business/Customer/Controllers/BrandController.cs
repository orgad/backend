using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/cust/brand/")]
    [EnableCors("any")]
    public class BrandController : ApiController
    {
        BrandService brandService = new BrandService();
        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = brandService.PageList(page);
            var totalCount = brandService.TotalCount();
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