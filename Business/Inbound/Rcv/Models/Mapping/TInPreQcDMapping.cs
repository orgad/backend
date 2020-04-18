using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInPreQcDMapping : IEntityTypeConfiguration<TInPreQcD>
    {
        public void Configure(EntityTypeBuilder<TInPreQcD> entity)
        {
            entity.ToTable("t_in_pre_qc_d");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HId).HasColumnName("h_id");
            entity.Property(e => e.NoticeId).HasColumnName("n_id");
            entity.Property(e => e.NoticeCode).HasColumnName("n_code");
            entity.Property(e => e.NoticeDId).HasColumnName("n_d_id");
            entity.Property(e => e.Carton).HasColumnName("carton");
            entity.Property(e => e.SkuId).HasColumnName("sku_id");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Barcode).HasColumnName("barcode");
            entity.Property(e => e.QcCode).HasColumnName("qc_code");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedTime).HasColumnName("last_modified_time");
        }
    }
}