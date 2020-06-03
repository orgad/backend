using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Auth.Models
{
    public class TPermBizMapping : IEntityTypeConfiguration<TPermBiz>
    {
        public void Configure(EntityTypeBuilder<TPermBiz> entity)
        {
            entity.ToTable("t_perm_business");

            entity.Property(e => e.Id)
               .HasColumnName("ID")
               .HasComment("主键ID");

            entity.Property(e => e.Code)
               .HasColumnType("varchar(100)")
               .HasComment("编码")
               .HasCharSet("utf8")
               .HasCollation("utf8_general_ci");

            entity.Property(e => e.WhId).HasColumnName("wh_id");
            entity.Property(e => e.WhCode).HasColumnName("wh_code");

            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.CustCode).HasColumnName("cust_code");

            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BrandCode).HasColumnName("brand_code");

            entity.Property(e =>e.BizCode).HasColumnName("biz_code");

            entity.Property(e => e.Comment)
              .HasColumnName("comment")
              .HasColumnType("varchar(100)")
              .HasComment("名称")
              .HasCharSet("utf8")
              .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreateBy)
                .HasColumnName("created_by")
                .HasColumnType("varchar(50)")
                .HasComment("创建人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
                .HasComment("创建时间");

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