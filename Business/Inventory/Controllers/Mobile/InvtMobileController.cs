using System.Web.Http;
using dotnet_wms_ef.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Mobile.Invt.Controllers
{
    [Route("/api/mobile/invt/")]
    [EnableCors("any")]
    public class InvtMobileController : ApiController
    {
        InventoryDetailService detailService = new InventoryDetailService();

        [Route("by-barcode")]
        [HttpGet]
        public JsonResult GetInvtByBarcode(string barcode)
        {
            var result = detailService.GetInvtByBarcode(barcode);
            return new JsonResult(result);
        }
        
        [Route("by-bin-code")]
        [HttpGet]
        public JsonResult GetInvtByBinCode(string binCode)
        {
            var result = detailService.GetInvtByBinCode(binCode);
            return new JsonResult(result);
        }
    }
}