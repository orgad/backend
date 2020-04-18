using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInPutAwayMapping : IEntityTypeConfiguration<TInPutaway>
    {
        public void Configure(EntityTypeBuilder<TInPutaway> entity)
        {
            entity.ToTable("t_in_putaway");

            entity.HasComment("上架任务");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主表ID");

            entity.Property(e => e.BinQty)
                .HasColumnName("bin_qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'0'")
                .HasComment("总库位数");

            entity.Property(e => e.CartonQty)
                .HasColumnName("carton_qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'0'")
                .HasComment("总箱数");

            entity.Property(e => e.Code)
                .HasColumnName("code")
                .HasColumnType("varchar(50)")
                .HasComment("主表编号")
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

            entity.Property(e => e.FirstScanAt)
                .HasColumnName("first_putaway_at")
                .HasColumnType("datetime")
                .HasComment("上架开始时间");

            entity.Property(e => e.InboundId)
                .HasColumnName("inbound_id")
                .HasColumnType("bigint(20)")
                .HasComment("入库单ID");

            entity.Property(e => e.InboundCode).HasColumnName("inbound_code");

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

            entity.Property(e => e.LastScanAt)
                .HasColumnName("last_putaway_at")
                .HasColumnType("datetime")
                .HasComment("上架结束时间");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'0'")
                .HasComment("总件数");

            entity.Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("varchar(30)")
                .HasComment("单据状态")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.WhId)
                .HasColumnName("wh_id")
                .HasColumnType("int(11)")
                .HasComment("仓库ID");
        }
    }
}