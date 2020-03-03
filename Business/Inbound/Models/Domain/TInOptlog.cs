using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInOptlog
    {
        public long Id { get; set; }
        public long? OrderId { get; set; }
        public string Store { get; set; }
        public string OptCode { get; set; }
        public string Carton { get; set; }
        public string Barcode { get; set; }
        public int? Qty { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
