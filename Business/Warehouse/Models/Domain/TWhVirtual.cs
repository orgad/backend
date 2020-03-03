using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TWhVirtual
    {
        public int Id { get; set; }
        public int WhId { get; set; }
        public int ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public int DutyId { get; set; }
        public string DutyCode { get; set; }
        public int BinId { get; set; }
        public string BinCode { get; set; }
        public int CustId { get; set; }
        public string CustCode { get; set; }
        public int BrandId { get; set; }
        public string BrandCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
