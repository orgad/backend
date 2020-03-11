using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
     public class TStRepDMapping:IEntityTypeConfiguration<TStRepD>
    {
        public void Configure(EntityTypeBuilder<TStRepD> entity)
        {
            entity.ToTable("t_st_rep_d");

                entity.HasComment("补货货位库存设置");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.BinCode)
                    .HasColumnName("bin_code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.BinId)
                    .HasColumnName("bin_id")
                    .HasColumnType("int(11)")
                    .HasComment("拣货货位");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("int(11)")
                    .HasComment("策略主表的ID");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'FALSE'");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("修改人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.MaxQty)
                    .HasColumnName("max_qty")
                    .HasColumnType("int(11)")
                    .HasComment("货位容量最大值");

                entity.Property(e => e.MinQty)
                    .HasColumnName("min_qty")
                    .HasColumnType("int(11)")
                    .HasComment("安全库存，低于这个库存就要补货了");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SkuId)
                    .HasColumnName("sku_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("SKU");

                entity.Property(e => e.ZoneCode)
                    .HasColumnName("zone_code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("拣货货区");
        }
    }
}