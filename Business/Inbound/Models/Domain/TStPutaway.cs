using System;

namespace dotnet_wms_ef.Models
{
    public partial class TStPutaway
    {
        public int Id { get; set; }
        public int HId { get; set; }
        public string TypeCode { get; set; }
        public bool IsDiffRetailECom { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}