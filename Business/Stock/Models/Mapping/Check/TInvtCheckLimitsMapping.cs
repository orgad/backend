using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Stock.Models
{
    public class TInvtCheckLimitsMapping : IEntityTypeConfiguration<TInvtCheckLimits>
    {
        public void Configure(EntityTypeBuilder<TInvtCheckLimits> entity)
        {
            entity.ToTable("t_invt_check_limits");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("盘点单ID 盘点单ID");
                
                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("类型");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("具体的ID sku_id,bin_id,duty_id,cust_id");
                
                entity.Property(e => e.ItemCode).HasColumnName("item_code");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

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
                
                entity.HasOne(d => d.TInvtCheck)
                   .WithMany(p => p.Limits)
                   .HasForeignKey(d => d.HId);
        }
    }
}