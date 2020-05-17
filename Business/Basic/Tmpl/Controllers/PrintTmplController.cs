using System.Web.Http;
using dotnet_wms_ef.Basic.Services;
using dotnet_wms_ef.Basic.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Basic.Controllers
{
    [Route("/api/basic/tmpl/print/")]
    [EnableCors("any")]
    public class PrintTmplController : ApiController
    {
        PrintTmplService service = new PrintTmplService();

        [Route("query")]
        public JsonResult GetTmpl(QueryTmpl query)
        {
            var result = service.TmplData(query);
            return new JsonResult(result);
        }
    }
}