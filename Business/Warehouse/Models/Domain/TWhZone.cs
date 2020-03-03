using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TWhZone
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? WhId { get; set; }
        public string TypeCode { get; set; }
        public string Comment { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
