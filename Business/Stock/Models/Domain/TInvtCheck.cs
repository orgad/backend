using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtCheck
    {
        public long Id { get; set; }
        public int? WhId { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string GoodsType { get; set; }
        public string TypeMode { get; set; }
        public string Status{get;set;}
        public string ScanStatus{get;set;}
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
