using System;

namespace dotnet_wms_ef.Basic.Models
{
    public partial class TTmplPrintD
    {
        public long Id { get; set; }
        public int TmplId { get; set; }
        public string TmplTitle { get; set; }
        public string TmplData { get; set; }
        public bool IsChild { get; set; }
        public int Seq { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
