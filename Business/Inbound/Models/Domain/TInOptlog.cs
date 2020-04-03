using System;
namespace dotnet_wms_ef.Models
{
    public partial class TInOptlog
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string OrderCode { get; set; }
        public string OptCode { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
