using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Basic.Models
{
    public partial class TTmplImportD
    {
        public long Id { get; set; }
        public int? TmplId { get; set; }
        public string TypeCode { get; set; }
        public string ColCode { get; set; }
        public string ColName { get; set; }
        public string DataType { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
