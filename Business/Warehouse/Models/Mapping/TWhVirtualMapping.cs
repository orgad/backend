using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TWhVirtualMapping : IEntityTypeConfiguration<TWhVirtual>
    {
        public void Configure(EntityTypeBuilder<TWhVirtual> entity)
        {
            entity.ToTable("t_wh_virtual");

            entity.HasComment("虚拟仓设置");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)");

            entity.Property(e => e.BinCode)
                .HasColumnName("bin_code")
                .HasColumnType("varchar(30)")
                .HasComment("货位")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.BinId)
                .HasColumnName("bin_id")
                .HasColumnType("int(11)")
                .HasComment("货位");

            entity.Property(e => e.BrandCode)
                .HasColumnName("brand_code")
                .HasColumnType("varchar(30)")
                .HasComment("品牌")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.BrandId)
                .HasColumnName("brand_id")
                .HasColumnType("int(11)")
                .HasComment("品牌");

            entity.Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("varchar(30)")
                .HasComment("创建人")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("datetime")
                .HasComment("创建时间");

            entity.Property(e => e.CustCode)
                .HasColumnName("cust_code")
                .HasColumnType("varchar(30)")
                .HasComment("客户")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.CustId)
                .HasColumnName("cust_id")
                .HasColumnType("int(11)")
                .HasComment("客户");

            entity.Property(e => e.DutyCode)
                .HasColumnName("duty_code")
                .HasColumnType("varchar(30)")
                .HasComment("货架")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.DutyId)
                .HasColumnName("duty_id")
                .HasColumnType("int(11)")
                .HasComment("货架");

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

            entity.Property(e => e.WhId)
                .HasColumnName("wh_id")
                .HasColumnType("int(11)")
                .HasComment("仓库");

            entity.Property(e => e.ZoneCode)
                .HasColumnName("zone_code")
                .HasColumnType("varchar(30)")
                .HasComment("货区")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ZoneId)
                .HasColumnName("zone_id")
                .HasColumnType("int(11)")
                .HasComment("货区");
        }
    }
}