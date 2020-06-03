using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermUserBiz
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public int BizId { get; set; }
        public string BizCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}