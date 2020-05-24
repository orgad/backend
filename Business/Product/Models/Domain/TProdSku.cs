using System;

namespace dotnet_wms_ef.Product.Models
{
    public partial class TProdSku
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int? ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public string Season { get; set; }
        public string Style { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public bool IsLot { get; set; }
        public bool IsSerial { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
