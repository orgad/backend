﻿using System;

namespace dotnet_wms_ef.Outbound.Models
{
    public partial class TOutHandover
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int WhId { get; set; }
        public int CustId { get; set; }
        public string Store { get; set; }
        public string Driver { get; set; }
        public string PlateNo { get; set; }
        public DateTime? FirstScanAt { get; set; }
        public DateTime? LastScanAt { get; set; }
        public string Comment { get; set; }
        public bool IsConfirm { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int Qty { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
