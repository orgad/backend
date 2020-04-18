using System;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInRn
    {
        public long Id { get; set; } //编号
        public string Code { get; set; } //单据编号 RN-yyyy-MM-dd-0000
        public string RefCode { get; set; } //客户方单号 来源于客户系统的单据编号
        public string RefSo { get; set; } //客户的采购单号
        public int WhId { get; set; } //仓库ID
        public int CustId { get; set; } //客户ID
        public int BrandId { get; set; } //品牌ID yyyyMMdd
        public string BatchNo { get; set; } //批号 客户有的话用客户的，没有自己输入一个
        public string BizCode { get; set; } //业务类型 零售/电商/只做标/混合
        public string GoodsType { get; set; } //货物类型 物料/商品 Mat/Prod
        public string TransCode { get; set; } //作业类型 入库/出库/退货/退仓/盘点/调整/移货/补货/冻结/解冻
        public string TypeCode { get; set; } //单据类型 到货通知单
        public string SrcCode { get; set; } //数据来源 导入Import,接口Interface
        public string Courier { get; set; } //承运商
        public string TrackingNo { get; set; } //物流单号
        public string Status { get; set; } //单据状态
        public int PkgStatus { get; set; }//包裹匹配状态
        public bool IsDeleted { get; set; } //是否删除
        public string CreatedBy { get; set; } //创建人
        public DateTime CreatedTime { get; set; } //创建时间
        public DateTime? LastModifiedTime { get; set; } //修改时间
        public string LastModifiedBy { get; set; } //修改人
    }
}