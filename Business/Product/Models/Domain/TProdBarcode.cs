using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TProdBarcode
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int? SkuId { get; set; }
        public string Barcode { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
