using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/sup/supplier/")]
    [EnableCors("any")]
    public class SupplierController
    {
        SupplierService supplierService = new SupplierService();

        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = supplierService.PageList(page);
            var totalCount = supplierService.TotalCount();
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