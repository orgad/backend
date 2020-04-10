using System;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class TInvtAdj
    {
        public long Id { get; set; }
        public int WhId { get; set; }
        public string Code { get; set; }
        public string CheckNo { get; set; }
        public string ReasonCode { get; set; }
        public string Status { get; set; }
        public bool IsCancel { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
