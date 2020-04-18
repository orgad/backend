using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInValueMapping : IEntityTypeConfiguration<TInValue>
    {
        public void Configure(EntityTypeBuilder<TInValue> entity)
        {
            entity.ToTable("t_in_value");

            entity.HasComment("增值服务");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主键");

            entity.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasColumnType("varchar(50)")
                .HasComment("备注")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasColumnName("created_by")
                .HasColumnType("varchar(50)")
                .HasComment("创建人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasComment("创建日期");

            entity.Property(e => e.HId)
                .HasColumnName("h_id")
                .HasColumnType("bigint(20)")
                .HasComment("外键");

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

            entity.Property(e => e.Photo)
                .HasColumnName("photo")
                .HasColumnType("varchar(500)")
                .HasComment("照片 价签照片")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Photo1)
                .HasColumnName("photo1")
                .HasColumnType("varchar(500)")
                .HasComment("照片1 全景照片")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Size)
                .HasColumnName("size")
                .HasColumnType("varchar(50)")
                .HasComment("尺码")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.SkuId)
                .HasColumnName("sku_id")
                .HasColumnType("int(11)")
                .HasComment("SKUID");
        }
    }
}