using System.Web.Http;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/cust/customer/")]
    [EnableCors("any")]
    public class CustomerController : ApiController
    {
        CustService custService = new CustService();

        [HttpGet]
        [Route("list")]
        public JsonResult List(int page)
        {
            var list = custService.PageList(page);
            var totalCount = custService.TotalCount();
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