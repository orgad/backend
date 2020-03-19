using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace dotnet_wms_ef.Models
{
    public partial class TOutDnD
    {
        public long Id { get; set; }
        public long? HId { get; set; }
        public string Store { get; set; }
        public string Product { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Carton { get; set; }
        public int Qty { get; set; }
        public decimal RetailPrice{get;set;}
        public decimal ActualPrice{get;set;}
        public decimal Discount{get;set;}
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        [IgnoreDataMember]
        public virtual TOutDn TOutDn{get;set;}
    }
}
