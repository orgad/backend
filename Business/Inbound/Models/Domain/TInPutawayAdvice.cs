using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class TInPutawayAdvice
    {
        public int Id { get; set; }
        public int? InboundId { get; set; }
        public string Carton { get; set; }
        public long? SkuId { get; set; }
        public string Barcode { get; set; }
        public int? Qty { get; set; }
        public string AdvZoneCode { get; set; }
        public string AdvBinCode { get; set; }
        public string ZoneCode { get; set; }
        public string BinCode { get; set; }
        public string Comment { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
