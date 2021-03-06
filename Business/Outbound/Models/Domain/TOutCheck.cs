﻿using System;

namespace dotnet_wms_ef.Outbound.Models
{
    public partial class TOutCheck
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int WhId { get; set; }
        public long OutboundId { get; set; }
        public string OutboundCode { get; set; }
        public long PickId { get; set; }
        public string PickCode { get; set; }
        public string Store { get; set; }
        public int Qty { get; set; }
        public int CartonQty { get; set; }
        public DateTime? FirstScanAt { get; set; }
        public DateTime? LastScanAt { get; set; }
        public bool IsCancel { get; set; }
        public bool IsConfirm { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
