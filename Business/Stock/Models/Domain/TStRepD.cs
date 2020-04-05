using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TStRepD
    {
        public long Id { get; set; }
        public int? HId { get; set; }
        public long? SkuId { get; set; }
        public string Sku { get; set; }
        public int? ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public int? BinId { get; set; }
        public string BinCode { get; set; }
        public int? MaxQty { get; set; }
        public int? MinQty { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
