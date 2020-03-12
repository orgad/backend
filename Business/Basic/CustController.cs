using dotnet_wms_ef.Services;
using dotnet_wms_ef.Views.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Linq;

namespace dotnet_wms_ef.Controllers
{
    public class CustController : ApiController
    {

        CustService custService = new CustService();
        BrandService brandService = new BrandService();

        [HttpGet]
        [Route("/api/outer/cust/customer/list")]
        [EnableCors("any")]
        public JsonResult List(int page)
        {
            var list = custService.PageList(page);
            var totalCount = custService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list.Select(x => new VBasicData { id = x.Id, code = x.Code, name = x.Code + x.NameCn }).ToList(),
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpGet]
        [Route("/api/outer/cust/brand/list/{id}")]
        [EnableCors("any")]
        public JsonResult BrandList(int Id)
        {
            var list = brandService.PageListByCustId(Id);
            var totalCount = custService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list.Select(x => new VBasicData { id = x.Id, code = x.Code, name = x.Code + x.NameLc }).ToList(),
                    TotalCount = totalCount
                }
                );

            return response;
        }
    }
}