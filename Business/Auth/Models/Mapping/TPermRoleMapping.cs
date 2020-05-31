using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermRoleMapping : IEntityTypeConfiguration<TPermRole>
    {
        public void Configure(EntityTypeBuilder<TPermRole> entity)
        {
            entity.ToTable("t_perm_role");

            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasComment("主键ID");

            entity.Property(e => e.Code)
                .HasColumnType("varchar(100)")
                .HasComment("编码")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.NameCn)
                .HasColumnName("name_cn")
                .HasColumnType("varchar(100)")
                .HasComment("名称")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

             entity.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasColumnType("varchar(100)")
                .HasComment("名称")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreateBy)
                .HasColumnName("created_by")
                .HasColumnType("varchar(50)")
                .HasComment("创建人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
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
        }
    }
}