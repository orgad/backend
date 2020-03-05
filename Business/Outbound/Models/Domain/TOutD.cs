using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Business.Models
{
    public partial class TOutD
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public string Product { get; set; }
        public int? SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Carton { get; set; }
        public int Qty { get; set; }
        public int? MatchingQty { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
