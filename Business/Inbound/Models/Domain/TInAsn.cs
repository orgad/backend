using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_wms_ef.Models
{
    public partial class TInAsn
    {   
        public TInAsn()
        {
            DetailList = new HashSet<TInAsnD>();
        }

        public long Id { get; set; }
        public string Code { get; set; }
        public string RefCode { get; set; }
        public string RefPo { get; set; }
        public int WhId { get; set; }
        public int CustId { get; set; }
        public int BrandId { get; set; }
        public string BatchNo { get; set; }
        public string BizCode { get; set; }
        public string GoodsType { get; set; }
        public string TransCode { get; set; }
        public string TypeCode { get; set; }
        public string SrcCode { get; set; }
        public bool? IsCiq { get; set; }
        public string InvoiceNo { get; set; }
        public string Status { get; set; }
        public string CheckStatus { get; set; }
        public DateTime? ExpAt { get; set; }
        public string DeliveyTo { get; set; }
        public float? Volume { get; set; }
        public int? CartonQty { get; set; }
        public int? PieceQty { get; set; }
        public float? Weight { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual ICollection<TInAsnD> DetailList{get;set;}
    }
}
