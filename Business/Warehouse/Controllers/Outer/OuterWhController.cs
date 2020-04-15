using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Linq;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/outer/wh/")]
    public class OuterWhController : ApiController
    {
        WhService whService = new WhService();
        ZoneService zoneService = new ZoneService();
        DutyService dutyService = new DutyService();
        BinService binService = new BinService();

        [HttpGet]
        [Route("warehouse/list")]
        [EnableCors("any")]
        public JsonResult WList(int page)
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

        [HttpGet]
        [Route("zone/list")]
        [EnableCors("any")]
        public JsonResult ZList(int page)
        {
            var list = zoneService.PageList(page);
            var totalCount = zoneService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list.Select(x => new VBasicData { id = x.Id, code = x.Code, name = x.Code }).ToList(),
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpGet]
        [Route("duty/list")]
        [EnableCors("any")]
        public JsonResult DList(int page)
        {
            var list = dutyService.PageList(page);
            var totalCount = dutyService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list.Select(x => new VBasicData { id = x.Id, code = x.Code, name = x.Code }).ToList(),
                    TotalCount = totalCount
                }
                );

            return response;
        }

        [HttpGet]
        [Route("/api/outer/wh/bin/list")]
        [EnableCors("any")]
        public JsonResult BList(int page)
        {
            var list = binService.PageList(page);
            var totalCount = binService.TotalCount();
            var response = new JsonResult(
                new SingleResponse
                {
                    Data = list.Select(x => new VBasicData { id = x.Id, code = x.Code, name = x.Code }).ToList(),
                    TotalCount = totalCount
                }
                );

            return response;
        }
    }
}