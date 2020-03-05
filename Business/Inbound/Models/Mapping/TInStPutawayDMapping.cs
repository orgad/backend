using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInStPutawayDMapping : IEntityTypeConfiguration<TStPutawayD>
    {
        public void Configure(EntityTypeBuilder<TStPutawayD> entity)
        {
            entity.ToTable("t_st_putaway_d");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HId).HasColumnName("h_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductCode).HasColumnName("product_code");
            entity.Property(e => e.ZoneId).HasColumnName("zone_id");
            entity.Property(e => e.ZoneCode).HasColumnName("zone_code");
            entity.Property(e => e.BinId).HasColumnName("bin_id");
            entity.Property(e => e.BinCode).HasColumnName("bin_id");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedTime).HasColumnName("last_modified_time");
        }
    }
}