using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Auth.Models
{
    public partial class TPermNav
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameCn { get; set; }
        public string PCode{get;set;}
        public string AllPath { get; set; }
        public string Seq { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
