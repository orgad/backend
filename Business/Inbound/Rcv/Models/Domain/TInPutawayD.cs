using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class TInPutawayD
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public int ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public int BinId { get; set; }
        public string BinCode { get; set; }
        public string Carton { get; set; }
        public long SkuId { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }
        public string Comment { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
