namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VCheckAddForm
    {
        public int WhId { get; set; }
        public string GoodsType{get;set;}
        public string TypeCode { get; set; }
        public string TypeMode { get; set; }
        public VLimits[] CheckLimits{get;set;}
    }
}