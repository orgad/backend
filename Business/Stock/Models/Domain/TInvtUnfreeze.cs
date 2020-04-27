using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtUnfreeze
    {
        public long Id { get; set; }
        public long FreezeId { get; set; }
        public long FreezeDId{get;set;}
        public string ReasonCode { get; set; }
        public int ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public int BinId { get; set; }
        public string BinCode { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
