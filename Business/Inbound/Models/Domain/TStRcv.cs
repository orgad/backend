using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TStRcv
    {
        public int Id { get; set; }
        public int? HId { get; set; }
        public ulong? AllowOut { get; set; }
        public float? OutRate { get; set; }
        public ulong? AllowBlind { get; set; }
        public string CheckList { get; set; }
        public string BackNode { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
