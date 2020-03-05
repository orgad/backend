using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Business.Models
{
    public partial class TOut
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string BatchNo { get; set; }
        public string RefNo { get; set; }
        public int? WhId { get; set; }
        public int? InboundId { get; set; }
        public int? DnId { get; set; }
        public string TransCode { get; set; }
        public string TypeCode { get; set; }
        public int CustId { get; set; }
        public int? BrandId { get; set; }
        public string Store { get; set; }
        public int? CartonQty { get; set; }
        public int? Qty { get; set; }
        public ulong? IsPriority { get; set; }
        public string ExpressNo { get; set; }
        public DateTime? ExpectAt { get; set; }
        public string Status { get; set; }
        public string ShipperCode { get; set; }
        public string ReceiverCode { get; set; }
        public string Comment { get; set; }
        public string BrandRemark { get; set; }
        public int AllotStatus { get; set; }
        public string PickStatus { get; set; }
        public string ScanStatus { get; set; }
        public string HandoverStatus { get; set; }
        public DateTime? ActualAt { get; set; }
        public ulong? IsCancel { get; set; }
        public ulong? IsConfirm { get; set; }
        public ulong IsPost { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
