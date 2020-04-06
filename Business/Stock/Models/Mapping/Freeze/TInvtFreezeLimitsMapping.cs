using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Stock.Models
{
    public class TInvtFreezeLimitsMapping : IEntityTypeConfiguration<TInvtFreezeLimits>
    {
        public void Configure(EntityTypeBuilder<TInvtFreezeLimits> entity)
        {
            entity.ToTable("t_invt_freeze_limits");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("冻结单ID 冻结单ID");
                
                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("类型");
                
                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("具体的ID sku_id,bin_id,duty_id,cust_id");

                entity.Property(e => e.ItemCode).HasColumnName("item_code");
                
                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasComment("是否删除");

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
                
                entity.HasOne(d => d.TInvtFreeze)
                   .WithMany(p => p.Limits)
                   .HasForeignKey(d => d.HId);
        }
    }
}