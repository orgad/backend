using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInLogMapping : IEntityTypeConfiguration<TInLog>
    {
        public void Configure(EntityTypeBuilder<TInLog> entity)
        {
            entity.ToTable("t_in_log");

            entity.HasComment("入库单据日志");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主键ID");

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

            entity.Property(e => e.OptCode)
                .HasColumnName("opt_code")
                .HasColumnType("varchar(50)")
                .HasComment("操作代码 新增/修改/删除/查询/打印/导出")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.OrderId)
                .HasColumnName("order_id")
                .HasColumnType("bigint(20)")
                .HasComment("单据ID");

            entity.Property(e =>e.OrderCode).HasColumnName("order_code");

            entity.Property(e => e.Source)
                .HasColumnName("source")
                .HasColumnType("varchar(50)")
                .HasComment("操作内容-原始 来源")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Target)
                .HasColumnName("target")
                .HasColumnType("varchar(50)")
                .HasComment("操作内容-目标 目标")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}