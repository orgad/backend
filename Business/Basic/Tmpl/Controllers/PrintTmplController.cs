using System.Web.Http;
using dotnet_wms_ef.Basic.Services;
using dotnet_wms_ef.Basic.ViewModels;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Basic.Controllers
{
    [Route("/api/basic/tmpl/print/")]
    [EnableCors("any")]
    public class PrintTmplController : ApiController
    {
        PrintTmplService service = new PrintTmplService();

        [Route("list")]
        public JsonResult List()
        {
            var o = service.PageList();
            var i = service.TotalCount();
            return new JsonResult(
                new SingleResponse { Data = o, TotalCount = i }
            );
        }

        [Route("{id}/details")]
        public JsonResult Details([FromUri] long id)
        {
            var result = service.Details(id);
            return new JsonResult(result);
        }

        [Route("{id}/tmpl-data")]
        public JsonResult TmplData([FromUri] long id)
        {
            var result = service.TmplDataById(id);
            return new JsonResult(result);
        }

        [Route("{id}/update-tmpl-data")]
        [HttpPut]
        public JsonResult UpdateTmplData([FromUri] long id,[FromBody]TmplData data)
        {
            var result = service.UpdateTmplData(id,data.Data);
            return new JsonResult(result);
        }

        [Route("query")]
        public JsonResult GetTmpl(QueryTmpl query)
        {
            var result = service.TmplData(query);
            return new JsonResult(result);
        }
    }
}