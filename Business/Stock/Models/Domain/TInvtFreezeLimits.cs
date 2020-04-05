using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtFreezeLimits
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public int? TypeCode { get; set; }
        public long? ItemId { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
