using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInRtnDMapping : IEntityTypeConfiguration<TInRnD>
    {
        public void Configure(EntityTypeBuilder<TInRnD> entity)
        {
            entity.ToTable("t_in_rn_d");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HId).HasColumnName("h_id");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedTime).HasColumnName("last_modified_time");
        }
    }
}