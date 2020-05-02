using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TProdCatalog
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int? PId { get; set; }
        public string CatLvl1 { get; set; }
        public string CatLvl2 { get; set; }
        public string CatLvl3 { get; set; }
        public string Name { get; set; }
        public string NameCn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
