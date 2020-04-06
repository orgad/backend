namespace dotnet_wms_ef.Stock.ViewModels
{
    public class VFreezeAddForm
    {
        public int WhId { get; set; }
        public string TypeMode { get; set; }
        public string ReasonCode { get; set; }
        public VLimits[] CheckLimits { get; set; }
    }
}