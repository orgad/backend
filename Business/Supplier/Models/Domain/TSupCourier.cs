using System;

namespace dotnet_wms_ef.Models
{
    public partial class TSupCourier
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string TypeCode { get; set; }
        public string Name { get; set; }
        public string NameCn { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
        public string Sign { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
