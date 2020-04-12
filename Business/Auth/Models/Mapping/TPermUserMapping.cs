using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermUserMapping : IEntityTypeConfiguration<TPermUser>
    {
        public void Configure(EntityTypeBuilder<TPermUser> entity)
        {
            entity.ToTable("t_perm_user");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键ID");

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

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(100)")
                .HasComment("电子邮箱")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.ExpireAt)
                .HasColumnName("expire_at")
                .HasColumnType("datetime")
                .HasComment("到期时间");

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

            entity.Property(e => e.LoginName)
                .HasColumnName("login_name")
                .HasColumnType("varchar(100)")
                .HasComment("登录名")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.NameCn)
                .HasColumnName("name_cn")
                .HasColumnType("varchar(100)")
                .HasComment("中文名")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.NameEn)
                .HasColumnName("name_en")
                .HasColumnType("varchar(100)")
                .HasComment("英文名")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Pwd)
                .HasColumnName("pwd")
                .HasColumnType("varchar(100)")
                .HasComment("密码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Sign)
                .HasColumnName("sign")
                .HasColumnType("varchar(100)")
                .HasComment("签名")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");
        }
    }
}