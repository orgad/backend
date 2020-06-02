using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermNavActionMapping : IEntityTypeConfiguration<TPermNavAction>
    {
        public void Configure(EntityTypeBuilder<TPermNavAction> entity)
        {
            entity.ToTable("t_perm_nav_action");

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.Property(e => e.Code)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasColumnName("code")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar(100)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.NavId).HasColumnName("nav_id");
            
            entity.Property(e => e.NavCode).HasColumnName("nav_code");

            entity.Property(e => e.Seq).HasColumnName("seq");
            
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