using System;

namespace dotnet_wms_ef.Models
{
    public partial class TStPutawayD
    {
        public int Id { get; set; }
        public int HId { get; set; }
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public long SkuId{get;set;}
        public string Sku{get;set;}
        public long ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public long BinId { get; set; }
        public string BinCode { get; set; }
         public int Qty { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual TStPutaway TStPutaway{get;set;}
    }
}