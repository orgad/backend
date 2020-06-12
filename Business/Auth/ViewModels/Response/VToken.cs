using System;

namespace dotnet_wms_ef.Auth.ViewModels
{
    public class VToken
    {
        public int StateCode { get; set; }
        public DateTime RequertAt { get; set; }
        public double ExpiresIn { get; set; }
        public string AccessToken { get; set; }
        public string Errors{get;set;}
    }
}