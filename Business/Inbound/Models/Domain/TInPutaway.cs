using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInPutaway
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int WhId { get; set; }
        public long InboundId { get; set; }
        public DateTime? FirstPutawayAt { get; set; }
        public DateTime? LastPutawayAt { get; set; }
        public string Status { get; set; }
        public int? CartonQty { get; set; }
        public int? BinQty { get; set; }
        public int? Qty { get; set; }
        public string Comment { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
