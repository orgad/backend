using System;

namespace dotnet_wms_ef.Auth.Models
{
    public partial class TPermRole
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameCn { get; set; }
        public string Comment{get;set;}
        public string CreateBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
