using System;
namespace dotnet_wms_ef.Inbound.Models
{
    public partial class TInOptlog
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string OrderCode { get; set; }
        public string OrderStatus { get; set; }
        public string OptStatus { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
