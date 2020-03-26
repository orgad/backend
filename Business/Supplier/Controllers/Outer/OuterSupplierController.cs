using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/outer/sup/")]
    [EnableCors("any")]
    public class OuterSupplierController : ApiController
    {
        CourierService courierService = new CourierService();
        
        [Route("courier/list")]
        public JsonResult List()
        {
            var result = new SingleResponse{
                Data = courierService.PageList(0),
                TotalCount = courierService.TotalCount()
            };
            return new JsonResult(result);
        }
    }
}