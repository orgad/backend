using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInvtReplenish
    {
        public long Id { get; set; }
        public long? PlanId { get; set; }
        public int? WhId { get; set; }
        public string Code { get; set; }
        public string Status { get; set; }
        public string DownStatus { get; set; }
        public string UpStatus { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
