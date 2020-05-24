using System.Web.Http;
using dotnet_wms_ef.Product.Services;
using dotnet_wms_ef.Product.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Product.Controllers
{
    [Route("/api/prod/mat/")]
    [EnableCors("any")]
    public class MaterialController : ApiController
    {
        MaterialService matService = new MaterialService();

        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = matService.PageList(page);
            var totalCount = matService.TotalCount();
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
        [Route("create")]
        public JsonResult Create([FromBody]VMatAddForm vMat)
        {
            var result = matService.Create(vMat);
            return new JsonResult(result);
        }

    }
}