using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermUserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public int RoleId { get; set; }
        public string RoleCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}