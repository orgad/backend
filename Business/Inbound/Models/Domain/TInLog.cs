using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInLog
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public string OptCode { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
