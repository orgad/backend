using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInInboundRcvMapping : IEntityTypeConfiguration<TInInboundRcv>
    {
        public void Configure(EntityTypeBuilder<TInInboundRcv> entity)
        {
            entity.ToTable("t_in_inbound_receiving");

            entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasColumnType("bigint(20)")
                   .HasComment("主键");

            entity.Property(e => e.HId)
                  .HasColumnName("h_id")
                  .HasColumnType("bigint(20)")
                  .HasComment("外键");
            
            entity.Property(e => e.Carton)
                .HasColumnName("carton")
                .HasColumnType("varchar(30)")
                .HasComment("箱号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.SkuId).HasColumnName("sku_id");

            entity.Property(e => e.Sku).HasColumnName("sku");

            entity.Property(e => e.Barcode)
                   .HasColumnName("barcode")
                   .HasColumnType("varchar(30)")
                   .HasComment("条码")
                   .HasCharSet("utf8")
                   .HasCollation("utf8_general_ci");

            entity.Property(e => e.Qty).HasColumnName("qty");

            entity.Property(e => e.CreatedBy).HasColumnName("created_by");

            entity.Property(e => e.CreatedTime)
            .HasColumnName("created_time")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasComment("创建时间");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'");

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