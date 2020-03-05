using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Business.Models
{
    public partial class TOutWave
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int? WhId { get; set; }
        public int? Size { get; set; }
        public int? SkuCatQty { get; set; }
        public int? SkuQty { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
