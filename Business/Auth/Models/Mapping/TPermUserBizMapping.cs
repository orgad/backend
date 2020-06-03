using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermUserBizMapping : IEntityTypeConfiguration<TPermUserBiz>
    {
        public void Configure(EntityTypeBuilder<TPermUserBiz> entity)
        {
            entity.ToTable("t_perm_user_biz");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键ID");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.Property(e => e.LoginName)
                .HasColumnName("login_name")
                .HasColumnType("varchar(100)")
                .HasComment("登录名")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.BizId).HasColumnName("biz_id");
            entity.Property(e => e.BizCode).HasColumnName("biz_code");

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