using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtCheckLimits
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public int? TypeCode { get; set; }
        public int? ItemId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
