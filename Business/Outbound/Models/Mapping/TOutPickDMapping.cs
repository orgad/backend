using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class TOutPickDMapping : IEntityTypeConfiguration<TOutPickD>
    {
        public void Configure(EntityTypeBuilder<TOutPickD> entity)
        {
            entity.ToTable("t_out_pick_d");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主键");

            entity.Property(e => e.ActBinCode)
                .HasColumnName("act_bin_code")
                .HasColumnType("varchar(30)")
                .HasComment("实际拣货货位")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.ActBinId)
                .HasColumnName("act_bin_id")
                .HasColumnType("int(11)");

            entity.Property(e => e.ActZoneCode)
                .HasColumnName("act_zone_code")
                .HasColumnType("varchar(30)")
                .HasComment("实际拣货货区")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.ActZoneId)
                .HasColumnName("act_zone_id")
                .HasColumnType("int(11)");

            entity.Property(e => e.Barcode)
                .HasColumnName("barcode")
                .HasColumnType("varchar(30)")
                .HasComment("条码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.BinCode)
                .HasColumnName("bin_code")
                .HasColumnType("varchar(30)")
                .HasComment("货位号")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.BinId)
                .HasColumnName("bin_id")
                .HasColumnType("int(11)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Carton)
                .HasColumnName("carton")
                .HasColumnType("varchar(30)")
                .HasComment("箱号")
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

            entity.Property(e => e.HId)
                .HasColumnName("h_id")
                .HasColumnType("bigint(20)")
                .HasComment("外键");

            entity.Property(e => e.IsIgnore)
                .HasColumnName("is_ignore")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'")
                .HasComment("是否跳过 缺货的情况会需要跳过");

            entity.Property(e => e.IsPicked)
                .HasColumnName("is_picked")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'")
                .HasComment("是否已拣货");

            entity.Property(e => e.IsSorted)
                .HasColumnName("is_sorted")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'")
                .HasComment("是否已分货");

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
                .HasDefaultValueSql("'1'")
                .HasComment("数量 待拣货数量,默认一行一件");

            entity.Property(e => e.ShouldPickBy)
                .HasColumnName("should_pick_by")
                .HasColumnType("varchar(30)")
                .HasComment("指定挑货人 默认为空")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Sku)
                .HasColumnName("sku")
                .HasColumnType("varchar(30)")
                .HasComment("SKU")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.SkuId)
                .HasColumnName("sku_id")
                .HasColumnType("int(11)");

            entity.Property(e => e.SortBy)
                .HasColumnName("sort_by")
                .HasColumnType("varchar(30)")
                .HasComment("分货人")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.SortCarton)
                .HasColumnName("sort_carton")
                .HasColumnType("varchar(30)")
                .HasComment("分货箱号")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.ZoneCode)
                .HasColumnName("zone_code")
                .HasColumnType("varchar(30)")
                .HasComment("货区号")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.ZoneId)
                .HasColumnName("zone_id")
                .HasColumnType("int(11)");

            entity.HasOne(d => d.TOutPick)
            .WithMany(p => p.DetailList)
            .HasForeignKey(d => d.HId);
        }
    }
}