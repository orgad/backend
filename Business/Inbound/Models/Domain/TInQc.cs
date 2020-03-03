﻿using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInQc
    {
        public long Id { get; set; }
        public long InboundId { get; set; }
        public string Code { get; set; }
        public DateTime? FirstScanAt { get; set; }
        public DateTime? LastScanAt { get; set; }
        public string Status { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
