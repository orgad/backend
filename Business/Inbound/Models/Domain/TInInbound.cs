using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class TInInbound
    {
        public TInInbound()
        {
            DetailList = new HashSet<TInInboundD>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public int WhId { get; set; }
        public int CustId { get; set; }
        public int BrandId { get; set; }
        public long AsnId { get; set; }
        public string AsnCode { get; set; }
        public string BizCode { get; set; }
        public string GoodsType { get; set; }
        public string TransCode { get; set; }
        public string TypeCode { get; set; }
        public string SrcCode { get; set; }
        public bool IsCiq { get; set; }
        public string BatchNo { get; set; }
        public string Store { get; set; }
        public int CartonQty { get; set; }
        public int Qty { get; set; }
        public string Comment { get; set; }
        public string RStatus { get; set; }
        public string QcStatus { get; set; }
        public string PStatus { get; set; }
        public string Status { get; set; }
        public bool IsCancel { get; set; }
        public bool IsConfirm { get; set; }
        public DateTime? ActualInAt { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual ICollection<TInInboundD> DetailList { get; set; }
    }
}
