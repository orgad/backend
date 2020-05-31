using System;

namespace dotnet_wms_ef.Auth.ViewModels
{
    public class VUser
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string TypeCode{get;set;}
        public string NameCn { get; set; }
        public string NameEn { get; set; }
        public string Email { get; set; }
        public DateTime? ExpireAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}