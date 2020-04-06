using System;
using System.Runtime.Serialization;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class TInInboundD
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public string Store { get; set; }
        public string Carton { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        [IgnoreDataMember]
        public virtual TInInbound TInInbound { get; set; }
    }
}
