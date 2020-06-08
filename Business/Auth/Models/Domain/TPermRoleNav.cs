using System;

namespace dotnet_wms_ef.Auth.Models
{
    public partial class TPermRoleNav
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string RoleCode { get; set; }
        public int NavId { get; set; }
        public string NavCode { get; set; }
        public int? ActionId { get; set; }
        public string ActionCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

    }
}