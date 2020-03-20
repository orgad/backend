using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Linq;

namespace dotnet_wms_ef.Controllers
{
    public class WhController : ApiController
    {

        WhService whService = new WhService();

        [HttpGet]
        [Route("/api/outer/wh/warehouse/list")]
        [EnableCors("any")]
        public JsonResult List(int page)
        {
            var list = whService.PageList(page);
            var totalCount = whService.TotalCount();
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