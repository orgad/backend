namespace dotnet_wms_ef.ViewModels
{
    public class VPickScanResponse : VOutScanResponse
    {
        /// 当前货位是否拣完
        public bool BinFinished { get; set; }
    }
}