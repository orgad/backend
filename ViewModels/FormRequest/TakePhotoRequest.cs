using Microsoft.AspNetCore.Http;

namespace dotnet_wms_ef.ViewModels
{
    public class TakePhotoRequest
    {
        public string desc{get;set;}

        public IFormFile file{get;set;}
    }
}