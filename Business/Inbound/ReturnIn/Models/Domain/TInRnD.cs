using System;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInRnD
    {
        public long Id { get; set; } //编号
        public long HId { get; set; } //退货通知ID
        public int Qty { get; set; } //数量
        public string Sku { get; set; } //SKU编号
        public string Barcode { get; set; } //条码 如果有SKUNo，就存SKUNo，如果没有，就存Barcode
        public bool IsDeleted { get; set; } //是否删除
        public string CreatedBy { get; set; } //创建人
        public DateTime CreatedTime { get; set; } //创建时间
        public string LastModifiedBy { get; set; } //修改人
        public DateTime? LastModifiedTime { get; set; } //修改时间
    }
}