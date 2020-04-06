namespace dotnet_wms_ef.Outbound.ViewModels
{
    public class VPickScanResponse : VOutScanResponse
    {
        /// 当前货位是否拣完
        public bool BinFinished { get; set; }
    }
}