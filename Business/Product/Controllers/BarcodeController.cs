using System.Web.Http;
using dotnet_wms_ef.Product.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/prod/barcode/")]
    [EnableCors("any")]
    public class BarcodeController:ApiController
    {
        BarcodeService barcodeService = new BarcodeService();

        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = barcodeService.PageList(page);
            var totalCount = barcodeService.TotalCount();
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