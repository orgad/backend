namespace dotnet_wms_ef.ViewModels
{
    public class VScanResponse
    {
        ///整单完成
        public bool IsAllFinished { get; set; }
        
        ///条码扫描完成
        public bool IsFinished { get; set; }

        public string Message { get; set; }
    }
}