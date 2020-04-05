using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtReplenishPlanD
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public long? SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int? ToZoneId { get; set; }
        public string ToZoneCode { get; set; }
        public int? ToBinId { get; set; }
        public string ToBinCode { get; set; }
        public int? Qty { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
