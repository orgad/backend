using System;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class TInAsnCiq
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public string Carton { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int? Qty { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
