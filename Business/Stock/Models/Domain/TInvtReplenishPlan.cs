﻿using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtReplenishPlan
    {
        public long Id { get; set; }
        public int? WhId { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string Status { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
