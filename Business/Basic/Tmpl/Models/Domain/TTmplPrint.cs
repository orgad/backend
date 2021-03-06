﻿using System;

namespace dotnet_wms_ef.Basic.Models
{
    public partial class TTmplPrint
    {
        public long Id { get; set; }
        public int? StId { get; set; }
        public string TypeCode { get; set; }
        public string SubTypeCode { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
