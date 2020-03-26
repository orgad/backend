using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TWhZonetypeMapping : IEntityTypeConfiguration<TWhZonetype>
    {
        public void Configure(EntityTypeBuilder<TWhZonetype> entity)
        {
            entity.ToTable("t_wh_zonetype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("修改人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.NameCn)
                    .HasColumnName("name_cn")
                    .HasColumnType("varchar(100)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
        }
    }
}