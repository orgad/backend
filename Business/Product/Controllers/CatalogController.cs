using System.Web.Http;
using dotnet_wms_ef.Product.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/prod/catalog/")]
    [EnableCors("any")]
    public class CatalogController : ApiController
    {
        CatalogService catalogService = new CatalogService();

        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = catalogService.PageList(page);
            var totalCount = catalogService.TotalCount();
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