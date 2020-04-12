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
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CodeNo)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");

            entity.Property(e => e.CreateBy)
                .HasColumnType("varchar(50)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.NameCn)
                .IsRequired()
                .HasColumnName("NameCN")
                .HasColumnType("varchar(100)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Seq)
                .HasColumnType("varchar(10)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.Property(e => e.UpdateBy)
                .HasColumnType("varchar(50)")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}