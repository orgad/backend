using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInStPutawayMapping : IEntityTypeConfiguration<TStPutaway>
    {
        public void Configure(EntityTypeBuilder<TStPutaway> entity)
        {
            entity.ToTable("t_st_putaway");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HId).HasColumnName("st_id");
            entity.Property(e => e.TypeCode).HasColumnName("type_code");
            entity.Property(e => e.IsDiffRetailECom).HasColumnName("is_diff_retail_ecom");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedTime).HasColumnName("last_modified_time");
        }
    }
}