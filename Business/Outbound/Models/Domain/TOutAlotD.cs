using System;
using System.Runtime.Serialization;

namespace dotnet_wms_ef.Outbound.Models
{
    public partial class TOutAlotD
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public string Product { get; set; }
        public long SkuId { get; set; }
        public string Barcode { get; set; }
        public string Carton { get; set; }
        public int Qty { get; set; }
        public long InvtDId { get; set; }
        public int MatchingQty { get; set; }
        public int ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public int BinId { get; set; }
        public string BinCode { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        
        [IgnoreDataMember]
        public virtual TOutAlot TOutAlot{get;set;}
    }
}
