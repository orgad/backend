using System;
using System.Runtime.Serialization;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtCheckLimits
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public string TypeCode { get; set; }
        public long ItemId { get; set; }
        public string ItemCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        [IgnoreDataMember]
        public virtual TInvtCheck TInvtCheck { get; set; }
    }
}
