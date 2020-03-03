using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TSt
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int WhId { get; set; }
        public int CustId { get; set; }
        public int BrandId { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
