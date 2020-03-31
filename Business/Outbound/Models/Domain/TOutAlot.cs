using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TOutAlot
    {
        public TOutAlot()
        {
            this.DetailList = new HashSet<TOutAlotD>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public long OutboundId { get; set; }
        public string OutboundCode { get; set; }
        public int WhId { get; set; }
        public bool IsCancel { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual ICollection<TOutAlotD> DetailList { get; set; }
    }
}
