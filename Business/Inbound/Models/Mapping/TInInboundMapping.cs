using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
     public class TInInboundMapping : IEntityTypeConfiguration<TInInbound>
    {
        public void Configure(EntityTypeBuilder<TInInbound> entity)
        {
            entity.ToTable("t_in_inbound");

                entity.HasComment("入库单主表");

                entity.HasIndex(e => e.CustId)
                    .HasName("IDX_T_In_Inbound_CustID");

                entity.HasIndex(e => e.TransCode)
                    .HasName("IDX_T_In_Inund_TransCodeD2BA");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("ID");

                entity.Property(e => e.ActualInAt)
                    .HasColumnName("actual_in_at")
                    .HasColumnType("datetime")
                    .HasComment("入库时间 上架确认的时间");

                entity.Property(e => e.AsnId)
                    .HasColumnName("asn_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("通知单号");

                entity.Property(e => e.BatchNo)
                    .HasColumnName("batch_no")
                    .HasColumnType("varchar(50)")
                    .HasComment("批号 客户有的话用客户的，没有自己输入一个")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BizCode)
                    .IsRequired()
                    .HasColumnName("biz_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("业务类型 零售/电商/标签/混合")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)")
                    .HasComment("品牌");

                entity.Property(e => e.CartonQty)
                    .HasColumnName("carton_qty")
                    .HasColumnType("int(11)")
                    .HasComment("总箱数");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(50)")
                    .HasComment("单号 RCV-yyyy-MM-dd-00000000")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(50)")
                    .HasComment("备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.CustId)
                    .HasColumnName("cust_id")
                    .HasColumnType("int(11)")
                    .HasComment("客户号");

                entity.Property(e => e.GoodsType)
                    .IsRequired()
                    .HasColumnName("goods_type")
                    .HasColumnType("varchar(30)")
                    .HasComment("货物类型 物料/商品 Mat/Prod")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.IsCancel)
                    .HasColumnName("is_cancel")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("是否取消");

                entity.Property(e => e.IsCiq)
                    .HasColumnName("is_ciq")
                    .HasColumnType("bit(1)")
                    .HasComment("是否有CIQ");

                entity.Property(e => e.IsConfirm)
                    .HasColumnName("is_confirm")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("是否确认 上架完成了就表示确认了");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("修改人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.PStatus)
                    .HasColumnName("p_status")
                    .HasColumnType("varchar(10)")
                    .HasComment("上架状态 未上架，上架中，已上架")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QcStatus)
                    .HasColumnName("qc_status")
                    .HasColumnType("varchar(10)")
                    .HasComment("质检状态 未质检，质检中，已质检")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("int(11)")
                    .HasComment("总数量");

                entity.Property(e => e.RStatus)
                    .HasColumnName("r_status")
                    .HasColumnType("varchar(10)")
                    .HasComment("收货状态 未收货，收货中，已收货")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SrcCode)
                    .IsRequired()
                    .HasColumnName("src_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("数据来源 导入Import,接口Interface")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(10)")
                    .HasComment("单据状态 未处理，已取消，已完成")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Store)
                    .HasColumnName("store")
                    .HasColumnType("varchar(50)")
                    .HasComment("店铺 一个店铺号或者为空，为空表示有多个店铺")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TransCode)
                    .IsRequired()
                    .HasColumnName("trans_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("作业类型 入库/出库/退货/退仓/盘点/调整/移货/补货/冻结/解冻")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("单据类型 正常,CIQ,质检")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasColumnType("int(11)")
                    .HasComment("仓库ID");
        }
    }
}