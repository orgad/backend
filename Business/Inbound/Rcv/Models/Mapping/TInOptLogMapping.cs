using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInOptLogMapping : IEntityTypeConfiguration<TInOptlog>
    {
        public void Configure(EntityTypeBuilder<TInOptlog> entity)
        {
            entity.ToTable("t_in_opt_log");

            entity.HasComment("收货扫描记录（一件一条/一箱一条)");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("编号");

            entity.Property(e => e.OrderId)
                .HasColumnName("order_id")
                .HasColumnType("bigint(20)")
                .HasComment("单据ID");

            entity.Property(e => e.OrderCode).HasColumnName("order_code");

            entity.Property(e => e.OrderStatus).HasColumnName("order_status");

            entity.Property(e => e.OptStatus)
                .HasColumnName("opt_status")
                .HasColumnType("varchar(30)")
                .HasComment("操作代码 收货")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.IsDeleted)
                  .HasColumnName("is_deleted")
                  .HasColumnType("bit(1)")
                  .HasDefaultValueSql("b'0'");

            entity.Property(e => e.CreatedBy)
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
        }
    }
}