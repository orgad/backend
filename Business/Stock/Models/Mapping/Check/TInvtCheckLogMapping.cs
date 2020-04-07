using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Stock.Models
{
    public class TInvtCheckLogMapping : IEntityTypeConfiguration<TInvtCheckLog>
    {
        public void Configure(EntityTypeBuilder<TInvtCheckLog> entity)
        {
            entity.ToTable("t_invt_check_log");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WhId).HasColumnName("wh_id");
            entity.Property(e => e.HId).HasColumnName("check_id");
            entity.Property(e => e.Code).HasColumnName("check_code");
            entity.Property(e => e.Carton).HasColumnName("carton");
            entity.Property(e => e.SkuId).HasColumnName("sku_id");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.ZoneId).HasColumnName("zone_id");
            entity.Property(e => e.ZoneCode).HasColumnName("zone_code");
            entity.Property(e => e.BinId).HasColumnName("bin_id");
            entity.Property(e => e.BinCode).HasColumnName("bin_code");
            entity.Property(e => e.Qty).HasColumnName("qty");
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
                .HasComment("创建时间");

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
        }
    }
}