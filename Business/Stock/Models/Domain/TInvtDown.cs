using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtDown
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public int? ToZoneId { get; set; }
        public int? ToBinId { get; set; }
        public string Carton { get; set; }
        public int? SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public decimal? Qty { get; set; }
        public int? FromZoneId { get; set; }
        public string FromZoneCode { get; set; }
        public int? FromBinId { get; set; }
        public string FromBinCode { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
