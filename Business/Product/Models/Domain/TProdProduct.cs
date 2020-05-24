using System;

namespace dotnet_wms_ef.Product.Models
{
    public partial class TProdProduct
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string BrandCode{get;set;}
        public int? CatalogId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
