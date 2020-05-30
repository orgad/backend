using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Outbound.Models
{
    public class TOutMapping : IEntityTypeConfiguration<TOut>
    {
        public void Configure(EntityTypeBuilder<TOut> entity)
        {
            entity.ToTable("t_out");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主键");

            entity.Property(e => e.ActualAt)
                .HasColumnName("actual_at")
                .HasColumnType("datetime")
                .HasComment("实际出库日期");
            
            entity.Property(e=>e.PlaceNo).HasColumnName("place_no");

            entity.Property(e => e.AllotStatus)
                .HasColumnName("allot_status")
                .HasColumnType("int(2)")
                .HasComment("-1= 分配失败: 分配失败的手工重置分配为0\\\\n0 = 未分配 \\\\n1 = 部分分配成功（至少要分配1件库存)\\\\n2 = 完全分配");

            entity.Property(e => e.BatchNo)
                .HasColumnName("batch_no")
                .HasColumnType("varchar(30)")
                .HasComment("批号,如有DN,从DN带入")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.BrandId)
                .HasColumnName("brand_id")
                .HasColumnType("int(11)")
                .HasComment("品牌");

            entity.Property(e => e.BrandRemark)
                .IsRequired()
                .HasColumnName("brand_remark")
                .HasColumnType("varchar(500)")
                .HasDefaultValueSql("''")
                .HasComment("品牌备注")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.CartonQty)
                .HasColumnName("carton_qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'0'")
                .HasComment("总箱数");

            entity.Property(e => e.Code)
                .HasColumnName("code")
                .HasColumnType("varchar(30)")
                .HasComment(@"出库单单号，规则为SHP2019XXXX0000001")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasColumnType("varchar(500)")
                .HasComment("备注")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("created_by")
                .HasColumnType("varchar(30)")
                .HasComment("创建人")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
                .HasComment("创建时间");

            entity.Property(e => e.CustId)
                .HasColumnName("cust_id")
                .HasColumnType("int(11)")
                .HasComment("客户");

            entity.Property(e => e.DnId)
                .HasColumnName("dn_id")
                .HasColumnType("bigint(20)")
                .HasComment("发货通知单");
            
            entity.Property(e => e.DnCode).HasColumnName("dn_code");

            entity.Property(e => e.ExpectAt)
                .HasColumnName("expect_at")
                .HasColumnType("datetime")
                .HasComment("期望发货日期");

            entity.Property(e => e.ExpressNo)
                .HasColumnName("express_no")
                .HasColumnType("varchar(30)")
                .HasComment("快递单号")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.HandoverStatus)
                .HasColumnName("handover_status")
                .HasColumnType("varchar(30)")
                .HasComment("交接状态")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.AsnId)
                .HasColumnName("asn_id")
                .HasColumnType("bigint(20)")
                .HasComment("到货通知单");

            entity.Property(e => e.IsCancel)
                .HasColumnName("is_cancel")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'")
                .HasComment("是否取消");

            entity.Property(e => e.IsConfirm)
                .HasColumnName("is_confirm")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'")
                .HasComment("是否确认");

            entity.Property(e => e.IsPost)
                .HasColumnName("is_post")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'")
                .HasComment("是否回传");

            entity.Property(e => e.IsPriority)
                .HasColumnName("is_priority")
                .HasColumnType("bit(1)")
                .HasComment("是否优先发货");

            entity.Property(e => e.LastModifiedBy)
                .HasColumnName("last_modified_by")
                .HasColumnType("varchar(30)")
                .HasComment("修改人")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.LastModifiedTime)
                .HasColumnName("last_modified_time")
                .HasColumnType("datetime")
                .HasComment("修改时间");

            entity.Property(e => e.PickStatus)
                .HasColumnName("pick_status")
                .HasColumnType("varchar(30)")
                .HasComment("拣货状态")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'0'")
                .HasComment("总件数");

            entity.Property(e => e.ReceiverCode)
                .HasColumnName("receiver_code")
                .HasColumnType("varchar(10)")
                .HasComment("收货人地址码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.RefNo)
                .HasColumnName("ref_no")
                .HasColumnType("varchar(30)")
                .HasComment("参考单号，来源于外部系统")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.ScanStatus)
                .HasColumnName("scan_status")
                .HasColumnType("varchar(30)")
                .HasComment("复核状态")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.ShipperCode)
                .HasColumnName("shipper_code")
                .HasColumnType("varchar(10)")
                .HasComment("发货人地址码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("varchar(30)")
                .HasComment("单据状态")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Store)
                .HasColumnName("store")
                .HasColumnType("varchar(30)")
                .HasDefaultValueSql("'0'")
                .HasComment("门店")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.TransCode)
                .IsRequired()
                .HasColumnName("trans_code")
                .HasColumnType("varchar(30)")
                .HasComment("业务类型：出库")
                .HasCharSet("armscii8")
                .HasCollation("armscii8_general_ci");

            entity.Property(e => e.TypeCode)
                .HasColumnName("type_code")
                .HasColumnType("varchar(30)")
                .HasComment("单据类型：出库单")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.WhId)
                .HasColumnName("wh_id")
                .HasColumnType("int(11)")
                .HasComment("仓库代码");

            entity.Property(e => e.BizCode).HasColumnName("biz_code");
            entity.Property(e => e.GoodsType).HasColumnName("goods_type");
            entity.Property(e =>e.SrcCode).HasColumnName("src_code");
            entity.Property(e => e.OrderPayment).HasColumnName("order_payment");
            entity.Property(e => e.Payment).HasColumnName("payment");
            entity.Property(e =>e.IsDeleted).HasColumnName("is_deleted");
        }
    }
}