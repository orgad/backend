namespace dotnet_wms_ef.Product.ViewModels
{
    public class VMatAddForm
    {
        public string Code { get; set; }
        public string Name { get; set; }
         public string Barcode { get; set; }
        public string PUom{get;set;}
        public string AUom{get;set;}
        public decimal PToA{get;set;}
        public decimal X { get; set; }
        public string XUnit { get; set; }
        public decimal Y { get; set; }
        public string YUnit { get; set; }
        public decimal Z { get; set; }
        public string ZUnit { get; set; }
    }
}