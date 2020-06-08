using System;

namespace dotnet_wms_ef.Auth.ViewModels
{
    public class VUserAdd
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TypeCode{get;set;}
        public string NameCn { get; set; }
        public string NameEn { get; set; }
        public string Email { get; set; }
    }
}