using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    [Route("/api/mobile/out/picking/")]
    [EnableCors("any")]
    public class AllPickMobileController:ApiController
    {
        
    }
}