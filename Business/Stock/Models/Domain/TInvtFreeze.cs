using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtFreeze
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string TypeMode { get; set; }
        public string ReasonCode { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
