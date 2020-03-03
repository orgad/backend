using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace dotnet_wms_ef.Models
{
    public partial class TInAsnD
    {
        public long Id { get; set; }
        public long HId { get; set; }

        public string Store { get; set; }
        public string Carton { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }
        public string ProductType { get; set; }
        public string Season { get; set; }
        public string ProductCode { get; set; }
        public string ProductNameEn { get; set; }
        public string ProductNameLc { get; set; }
        public string ColorCode { get; set; }
        public string ColorNameEn { get; set; }
        public string ColorNameLc { get; set; }
        public string SizeCode { get; set; }
        public string SizeEn { get; set; }
        public string SizeLc { get; set; }
        public string OriginEn { get; set; }
        public string OriginLc { get; set; }
        public string StandardCode { get; set; }
        public string SafeClass { get; set; }
        public DateTime? ProductionDate { get; set; }
        public float? RetailPrice { get; set; }
        public float? DeclarationPrice { get; set; }
        public string Gender { get; set; }
        public string Dimension { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        [IgnoreDataMember]
        public virtual TInAsn TInAsn { get; set; }
    }
}
