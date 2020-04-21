using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtFreeze
    {
        public TInvtFreeze()
        {
            this.Limits = new HashSet<TInvtFreezeLimits>();
        }
        public long Id { get; set; }
        public string Code { get; set; }
        public string TypeMode { get; set; }
        public string ReasonCode { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedBy { get; set; }

        public virtual ICollection<TInvtFreezeLimits> Limits{get;set;}
    }
}
