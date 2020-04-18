using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInRtnPkgMapping : IEntityTypeConfiguration<TInRnPkg>
    {
        public void Configure(EntityTypeBuilder<TInRnPkg> entity)
        {
            entity.ToTable("t_in_rn_pkg");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Courier).HasColumnName("courier");
            entity.Property(e => e.TrackingNo).HasColumnName("tracking_no");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedTime).HasColumnName("last_modified_time");
        }
    }
}