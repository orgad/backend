using System;

namespace dotnet_wms_ef.Auth.Models
{
    public partial class TPermNavAction
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int NavId { get; set; }
        public string NavCode { get; set; }
        public int Seq { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}