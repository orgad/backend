using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Business.Models
{
    public partial class TOutDn
    {
        public TOutDn()
        {
            this.DetailList = new TOutDnD[]{};
        }
        public long Id { get; set; }
        public int? InboundId { get; set; }
        public string Code { get; set; }
        public string RefNo { get; set; }
        public string BatchNo { get; set; }
        public int WhId { get; set; }
        public int CustId { get; set; }
        public int BrandId { get; set; }
        public int BizCode { get; set; }
        public string TransCode { get; set; }
        public string GoodsType { get; set; }
        public string TypeCode{get;set;}
        public string SrcCode { get; set; }
        public string Store { get; set; }
        public int? CartonQty { get; set; }
        public int? Qty { get; set; }
        public DateTime? ExpectAt { get; set; }
        public string ShipperCode { get; set; }
        public string ReceiverCode { get; set; }
        public string Status { get; set; }
        public decimal OrderPayment{get;set;}
        public decimal Payment{get;set;}
        public string Comment { get; set; }
        public string BrandRemark { get; set; }
        public ulong? IsCancel { get; set; }
        public ulong? IsConfirm { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual TOutDnD[] DetailList{get;set;}
    }
}
