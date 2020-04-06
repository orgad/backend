using System;

namespace dotnet_wms_ef.Outbound.Models
{
    public partial class TStDelivery
    {
        public int Id { get; set; }
        public int? HId { get; set; }
        public ulong? IsNeedExpress { get; set; }
        public string ExpressNode { get; set; }
        public string OutboundNode { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
