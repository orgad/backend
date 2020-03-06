using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInCheckD
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public string TypeCode { get; set; }
        public string Carton { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public string Comment1 { get; set; }
        public string Photo1 { get; set; }
        public string Comment2 { get; set; }
        public string Photo2 { get; set; }
        public string Comment3 { get; set; }
        public string Photo3 { get; set; }
        public string Comment4 { get; set; }
        public string Photo4 { get; set; }
        public string Comment5 { get; set; }
        public string Photo5 { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
