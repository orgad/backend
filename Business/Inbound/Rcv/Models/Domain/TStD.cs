using System;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class TStD
    {
        public int Id { get; set; }
        public int HId { get; set; }
        public string OptCode { get; set; }
        public int Seq { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
