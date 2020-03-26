using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/outer/cust/")]
    [EnableCors("any")]
    public class OuterCustController : ApiController
    {

        CustService custService = new CustService();
        BrandService brandService = new BrandService();

        ShopService shopService = new ShopService();

        [HttpGet]
        [Route("customer/list")]
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
        [Route("brand/list/{id}")]
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

        [HttpGet]
        [Route("shop/list/{id}")]
        public JsonResult StoreList(int Id)
        {
            var list = shopService.PageListByCustId(Id);
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