using Microsoft.AspNetCore.Mvc;

namespace dotnet_wms_ef.Controllers
{
    public class SingleResponse
    {
        public int TotalCount { get; set; }


        public object data { get; set; }
    }
}