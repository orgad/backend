using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInRtnMapping : IEntityTypeConfiguration<TInRn>
    {
        public void Configure(EntityTypeBuilder<TInRn> entity)
        {
            entity.ToTable("t_in_rn");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.RefCode).HasColumnName("ref_code");
            entity.Property(e => e.RefPo).HasColumnName("ref_po");
            entity.Property(e => e.WhId).HasColumnName("wh_id");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BatchNo).HasColumnName("batch_no");
            entity.Property(e => e.BizCode).HasColumnName("biz_code");
            entity.Property(e => e.GoodsType).HasColumnName("goods_type");
            entity.Property(e => e.TransCode).HasColumnName("trans_code");
            entity.Property(e => e.TypeCode).HasColumnName("type_code");
            entity.Property(e => e.SrcCode).HasColumnName("src_code");
            entity.Property(e => e.Courier).HasColumnName("courier");
            entity.Property(e => e.TrackingNo).HasColumnName("tracking_no");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.PkgStatus).HasColumnName("pkg_status");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedTime).HasColumnName("created_time");
            entity.Property(e => e.LastModifiedBy).HasColumnName("last_modified_by");
            entity.Property(e => e.LastModifiedTime).HasColumnName("last_modified_time");
        }
    }
}