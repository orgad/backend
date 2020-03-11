﻿using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInvtUp
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public int? ToZoneId { get; set; }
        public string ToZoneCode { get; set; }
        public int? ToBinId { get; set; }
        public string ToBinCode { get; set; }
        public string Carton { get; set; }
        public int? SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public decimal? Qty { get; set; }
        public int? FromBinId { get; set; }
        public int? FromZoneId { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
