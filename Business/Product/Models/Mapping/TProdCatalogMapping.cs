using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TProdCatalogMapping : IEntityTypeConfiguration<TProdCatalog>
    {
        public void Configure(EntityTypeBuilder<TProdCatalog> entity)
        {
            entity.ToTable("t_prod_catalog");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasColumnName("code")
                .HasColumnType("varchar(30)")
                .HasComment("分类代码 ")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("created_by")
                .HasColumnType("varchar(30)")
                .HasComment("创建人 ")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
                .HasComment("创建时间 ");

            entity.Property(e => e.LastModifiedBy)
                .HasColumnName("last_modified_by")
                .HasColumnType("varchar(30)")
                .HasComment("修改人 ")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.LastModifiedTime)
                .HasColumnName("last_modified_time")
                .HasColumnType("datetime")
                .HasComment("修改时间 ");

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)")
                .HasComment("分类名称 ")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.NameCn)
                .HasColumnName("name_cn")
                .HasColumnType("varchar(50)")
                .HasComment("中文分类名称 ")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.PId)
                .HasColumnName("p_id")
                .HasComment("上级分类 ");
        }
    }
}