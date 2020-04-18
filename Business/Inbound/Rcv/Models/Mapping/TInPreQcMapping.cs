using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInPreQcMapping : IEntityTypeConfiguration<TInPreQc>
    {
        public void Configure(EntityTypeBuilder<TInPreQc> entity)
        {
            entity.ToTable("t_in_pre_qc");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WhId).HasColumnName("wh_id");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.SrcCode).HasColumnName("src_code");
            entity.Property(e => e.TrackingNo).HasColumnName("tracking_no");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CartonQty).HasColumnName("carton_qty");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.InBatchCode).HasColumnName("in_batch_code");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedTime).HasColumnName("last_modified_time");
        }
    }
}