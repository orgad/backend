using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Outbound.Models
{
    public partial class TOutCheckD
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public string Carton { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }
        public string ProductSn { get; set; }
        public string Comment { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? Volume { get; set; }
        public string CartonTypeCode { get; set; }
        public string CartonType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
