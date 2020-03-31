namespace dotnet_wms_ef.ViewModels
{
    public class VOutScanResponse
    {   
        /// 整单是否拣完
        public bool AllFinished { get; set; }

        /// 返回信息:当前货位的>  sku拣选数量/总数量
        /// 返回信息:SKU的总数量> 整单数量 AllQty 
        /// CurrentBin bySku : CurrentQty/TotalQty
        public string Message{get;set;}
    }
}