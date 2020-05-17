using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Basic.Models
{
    public partial class TTmplPrintConfig
    {
        public long Id { get; set; }
        public int? TmplId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
