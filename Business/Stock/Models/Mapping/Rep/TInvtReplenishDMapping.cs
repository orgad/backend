using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
     public class TInvtReplenishDMapping:IEntityTypeConfiguration<TInvtReplenishD>
    {
        public void Configure(EntityTypeBuilder<TInvtReplenishD> entity)
        {
            entity.ToTable("t_invt_replenish_d");

                entity.HasComment("补货任务明细");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.ActualQty)
                    .HasColumnName("actual_qty")
                    .HasColumnType("int(11)")
                    .HasComment("补货扫描的数量");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(30)")
                    .HasComment("条码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

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

                entity.Property(e => e.FromBinCode)
                    .HasColumnName("from_bin_code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FromBinId)
                    .HasColumnName("from_bin_id")
                    .HasColumnType("int(11)")
                    .HasComment("来源货位");

                entity.Property(e => e.FromZoneCode)
                    .HasColumnName("from_zone_code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FromZoneId)
                    .HasColumnName("from_zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("来源货区");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("int(11)")
                    .HasComment("补货任务ID");

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

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("int(11)")
                    .HasComment("补货任务数量");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SkuId)
                    .HasColumnName("sku_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("SKU");

                entity.Property(e => e.ToBinCode)
                    .HasColumnName("to_bin_code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ToBinId)
                    .HasColumnName("to_bin_id")
                    .HasColumnType("int(11)")
                    .HasComment("目的货位");

                entity.Property(e => e.ToZoneCode)
                    .HasColumnName("to_zone_code")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ToZoneId)
                    .HasColumnName("to_zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("目的货区");
        }
    }
}