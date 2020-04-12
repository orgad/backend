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

            entity.Property(e => e.CodeNo)
                .HasColumnType("varchar(100)")
                .HasComment("编码")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreateAt)
                .HasColumnType("datetime")
                .HasComment("创建时间");

            entity.Property(e => e.CreateBy)
                .HasColumnType("varchar(50)")
                .HasComment("创建人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.NameCn)
                .HasColumnName("NameCN")
                .HasColumnType("varchar(100)")
                .HasComment("名称")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasComment("修改时间");

            entity.Property(e => e.UpdateBy)
                .HasColumnType("varchar(50)")
                .HasComment("修改人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}