using Microsoft.AspNetCore.Http;

namespace dotnet_wms_ef.Views
{
    public class TakePhotoRequest
    {
        public string desc{get;set;}

        public IFormFile file{get;set;}
    }
}