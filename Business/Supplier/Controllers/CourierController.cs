using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/sup/courier/")]
    [EnableCors("any")]
    public class CourierController
    {
        CourierService courierService = new CourierService();

        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = courierService.PageList(page);
            var totalCount = courierService.TotalCount();
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