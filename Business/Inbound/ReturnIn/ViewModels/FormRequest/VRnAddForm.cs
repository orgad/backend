namespace dotnet_wms_ef.Inbound.ViewModels
{
    public class VRnAddForm
    {
         public string RefCode { get; set; } //客户方单号 来源于客户系统的单据编号
        public string RefPo { get; set; } //客户的采购单号
        public int WhId { get; set; } //仓库ID
        public int CustId { get; set; } //客户ID
        public int BrandId { get; set; } //品牌ID yyyyMMdd
        public string BatchNo { get; set; } //批号 客户有的话用客户的，没有自己输入一个
        public string BizCode { get; set; } //业务类型 零售/电商/只做标/混合
        public string GoodsType { get; set; } //货物类型 物料/商品 Mat/Prod
        public string Courier { get; set; } //承运商
        public string TrackingNo { get; set; } //物流单号
    }
}