using dotnet_wms_ef.Mobile.ReturnIn.ViewModels;
using dotnet_wms_ef.ReturnIn.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Mobile.ReturnIn.Controllers
{
    [Route("/api/mobile/return-in/")]
    [EnableCors("any")]
     public class ReturnInMobileController
     {
         ReturnInService returnInService = new ReturnInService();

         [Route("scan")]
         [HttpPost]
         public JsonResult Scan([FromBody]VPkgScan pkg)
         {
             var result = returnInService.Scan(pkg);
             return new JsonResult(result);
         }
     }
}