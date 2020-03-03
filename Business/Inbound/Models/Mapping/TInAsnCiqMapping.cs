using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInAsnCiqMapping : IEntityTypeConfiguration<TInAsnCiq>
    {
        public void Configure(EntityTypeBuilder<TInAsnCiq> entity)
        {
            entity.ToTable("t_in_asn_ciq");

            entity.HasComment("CIQ到货明细");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主键");

            entity.Property(e => e.Barcode)
                .IsRequired()
                .HasColumnName("barcode")
                .HasColumnType("varchar(30)")
                .HasComment("条码")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Carton)
                .HasColumnName("carton")
                .HasColumnType("varchar(50)")
                .HasComment("箱号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("created_by")
                .HasColumnType("varchar(30)")
                .HasComment("创建人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建时间");

            entity.Property(e => e.HId)
                .HasColumnName("h_id")
                .HasColumnType("bigint(20)")
                .HasComment("外键");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'");

            entity.Property(e => e.LastModifiedBy)
                .HasColumnName("last_modified_by")
                .HasColumnType("varchar(30)")
                .HasComment("修改人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.LastModifiedTime)
                .HasColumnName("last_modified_time")
                .HasColumnType("datetime")
                .HasComment("修改时间");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasColumnType("int(11)")
                .HasComment("数量");

            entity.Property(e => e.Sku)
                .HasColumnName("sku")
                .HasColumnType("varchar(30)")
                .HasComment("货品编码")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
        }
    }
}