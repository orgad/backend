using System;
using System.Runtime.Serialization;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtFreezeD
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public int? BinId { get; set; }
        public string BinCode { get; set; }
        public long? SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public decimal? Qty { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
