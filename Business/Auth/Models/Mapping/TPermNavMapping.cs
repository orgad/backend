using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermNavMapping : IEntityTypeConfiguration<TPermNav>
    {
        public void Configure(EntityTypeBuilder<TPermNav> entity)
        {
            entity.ToTable("t_perm_nav");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.AllPath)
                .HasColumnType("varchar(100)")
                .HasColumnName("all_path")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e =>e.PId).HasColumnName("p_id");
            entity.Property(e =>e.PCode).HasColumnName("p_code");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("code")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.NameCn)
                .IsRequired()
                .HasColumnName("name_cn")
                .HasColumnType("varchar(100)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Seq)
                .HasColumnType("varchar(10)")
                .HasColumnName("seq")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedTime).HasColumnType("datetime")
                .HasColumnName("created_time");

            entity.Property(e => e.CreatedBy).HasColumnName("created_by")
                .HasColumnType("varchar(50)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.LastModifiedTime).HasColumnType("datetime").HasColumnName("last_modified_time");

            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by")
                .HasColumnType("varchar(50)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}