using System;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInPreQcD
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public long NoticeId { get; set; }
        public string NoticeCode { get; set; }
        public long NoticeDId { get; set; }
        public string Carton { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public string QcCode { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedTime { get; set; }
    }
}