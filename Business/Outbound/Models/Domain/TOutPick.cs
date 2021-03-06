﻿using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Outbound.Models
{
    public partial class TOutPick
    {
        public TOutPick()
        {
           this.DetailList = new HashSet<TOutPickD>{};
        }
        public long Id { get; set; }
        public string Code { get; set; }
        public int WhId { get; set; }
        public long WaveId { get; set; }
        public string WaveCode { get; set; }
        public long OutboundId { get; set; }
        public string OutboundCode { get; set; }
        public string Store { get; set; }
        public int BinQty { get; set; }
        public int CartonQty { get; set; }
        public int Qty { get; set; }
        public DateTime? FirstScanAt { get; set; }
        public DateTime? LastScanAt { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
        public ulong? IsCancel { get; set; }
        public ulong? IsConfirm { get; set; }
        public DateTime? Printat { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual ICollection<TOutPickD> DetailList{get;set;}
    }
}
