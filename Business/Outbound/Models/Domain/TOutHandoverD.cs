using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TOutHandoverD
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public string Courier { get; set; }
        public string ExpressNo { get; set; }
        public string Pallet { get; set; }
        public string Carton { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
