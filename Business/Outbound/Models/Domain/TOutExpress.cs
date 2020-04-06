using System;

namespace dotnet_wms_ef.Outbound.Models
{
    public partial class TOutExpress
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long? OutboundId { get; set; }
        public string OutboundCode { get; set; }
        public string Courier { get; set; }
        public string ExpressOrderId { get; set; }
        public string ExpressTrackingNo { get; set; }
        public int ExpressPages { get; set; }
        public string DestCityCode { get; set; }
        public ulong IsPrintExpress { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
