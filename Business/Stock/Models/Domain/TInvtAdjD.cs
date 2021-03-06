﻿using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtAdjD
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public int? ZoneId { get; set; }
        public int? BinId { get; set; }
        public int? SkuId { get; set; }
        public decimal? Qty { get; set; }
        public string Barcode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
