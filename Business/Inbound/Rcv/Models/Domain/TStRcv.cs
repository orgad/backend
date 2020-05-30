using System;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class TStRcv
    {
        public int Id { get; set; }
        public int HId { get; set; }
        public string ScanTypeCode{get;set;}
        public bool AllowOut { get; set; }
        public decimal OutRate { get; set; }
        public bool AllowBlind { get; set; }
        public string CheckList { get; set; }
        public string BackNode { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
