using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Business.Models
{
    public partial class TOutPickD
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public string BinId { get; set; }
        public string BinCode { get; set; }
        public string Carton { get; set; }
        public int? SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }
        public int? ActZoneId { get; set; }
        public string ActZoneCode { get; set; }
        public int? ActBinId { get; set; }
        public string ActBinCode { get; set; }
        public ulong IsPicked { get; set; }
        public ulong IsSorted { get; set; }
        public ulong IsIgnore { get; set; }
        public string ShouldPickBy { get; set; }
        public string SortBy { get; set; }
        public string SortCarton { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
