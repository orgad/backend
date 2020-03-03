using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
     public class TInQcMapping : IEntityTypeConfiguration<TInQc>
    {
        public void Configure(EntityTypeBuilder<TInQc> entity)
        {
             entity.ToTable("t_in_qc");

                entity.HasComment("质检任务");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键ID");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(50)")
                    .HasComment("质检单号 QC-yyyy-MM-dd-00000000")
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
                    .HasColumnName("first_scan_at")
                    .HasColumnType("datetime")
                    .HasComment("首次扫描时间");

                entity.Property(e => e.InboundId)
                    .HasColumnName("inbound_id")
                    .HasColumnType("bigint(20)");

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
                    .HasColumnName("last_scan_at")
                    .HasColumnType("datetime")
                    .HasComment("最后扫描时间");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(30)")
                    .HasComment("单据状态 未处理/质检中/质检完成")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
        }
    }
}