using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInvtMovePlan
    {
        public long Id { get; set; }
        public int? WhId { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string Status { get; set; }
        public string MovStatus { get; set; }
        public int? FromZoneId { get; set; }
        public int? ToZoneId { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
