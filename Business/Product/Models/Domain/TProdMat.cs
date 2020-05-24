using System;

namespace dotnet_wms_ef.Product.Models
{
    public class TProdMat
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string CatLvl_1 { get; set; }
        public string CatLvl_2 { get; set; }
        public string CatLvl_3 { get; set; }
        public string Spec { get; set; }
        public decimal X { get; set; }
        public string XUnit { get; set; }
        public decimal Y { get; set; }
        public string YUnit { get; set; }
        public decimal Z { get; set; }
        public string ZUnit { get; set; }
        public string PUom { get; set; }
        public decimal PToA { get; set; }
        public string AUom { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
