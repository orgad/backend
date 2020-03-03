using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TWhBin
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string SizeCode { get; set; }
        public string LocateCode { get; set; }
        public int WhId { get; set; }
        public int ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public int DutyId { get; set; }
        public string DutyCode { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
        public string Comment { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
