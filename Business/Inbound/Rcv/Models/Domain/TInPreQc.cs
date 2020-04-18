using System;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInPreQc
    {
        public long Id { get; set; }
        public string TrackingNo { get; set; }
        public string Code { get; set; }
        public int CartonQty { get; set; }
        public int Qty { get; set; }
        public string InBatchCode { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedTime { get; set; }
    }
}