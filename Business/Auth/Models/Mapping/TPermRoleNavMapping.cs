using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermRoleNavMapping : IEntityTypeConfiguration<TPermRoleNav>
    {
        public void Configure(EntityTypeBuilder<TPermRoleNav> entity)
        {
            entity.ToTable("t_perm_role_nav_action");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键ID");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleCode).HasColumnName("role_code");

            entity.Property(e => e.NavId).HasColumnName("nav_id");
            entity.Property(e => e.NavCode).HasColumnName("nav_code");

            entity.Property(e => e.ActionId).HasColumnName("action_id");
            entity.Property(e => e.ActionCode).HasColumnName("action_code");

            entity.Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("varchar(30)")
                .HasComment("创建人")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
                .HasComment("创建时间");

            entity.Property(e => e.LastModifiedBy)
                .HasColumnName("last_modified_by")
                .HasColumnType("varchar(30)")
                .HasComment("修改时间")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.LastModifiedTime)
                .HasColumnName("last_modified_time")
                .HasColumnType("datetime")
                .HasComment("修改人");
        }
    }
}