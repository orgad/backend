
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Basic.Models
{
    public class TTmplPrintMapping : IEntityTypeConfiguration<TTmplPrint>
    {
        public void Configure(EntityTypeBuilder<TTmplPrint> entity)
        {
            entity.ToTable("t_tmpl_print");

                entity.HasComment("打印模板主表");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StId).HasColumnName("st_id");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("模板类型")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SubTypeCode)
                    .HasColumnName("sub_type_code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime");
        }
    }
}