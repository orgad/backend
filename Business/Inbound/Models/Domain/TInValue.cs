using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInValue
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public int? SkuId { get; set; }
        public string Size { get; set; }
        public string Photo { get; set; }
        public string Photo1 { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
