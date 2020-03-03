using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInvtMapping: IEntityTypeConfiguration<TInvt>
    {
        public void Configure(EntityTypeBuilder<TInvt> entity)
        {
             entity.ToTable("t_invt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("主键");

                entity.Property(e => e.AlotQty)
                    .HasColumnName("alot_qty")
                    .HasDefaultValueSql("'0'")
                    .HasComment("分配数量");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(30)")
                    .HasComment("条码")
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

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

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

                entity.Property(e => e.LockedQty)
                    .HasColumnName("locked_qty")
                    .HasDefaultValueSql("'0'")
                    .HasComment("冻结数量");

                entity.Property(e => e.Other01)
                    .HasColumnName("other_01")
                    .HasColumnType("varchar(30)")
                    .HasComment("预留字段")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Other02)
                    .HasColumnName("other_02")
                    .HasColumnType("varchar(30)")
                    .HasComment("预留字段")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Other03)
                    .HasColumnName("other_03")
                    .HasColumnType("varchar(30)")
                    .HasComment("预留字段")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Other04)
                    .HasColumnName("other_04")
                    .HasColumnType("varchar(30)")
                    .HasComment("预留字段")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Other05)
                    .HasColumnName("other_05")
                    .HasColumnType("varchar(30)")
                    .HasComment("预留字段")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasComment("在库数量");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasColumnType("varchar(30)")
                    .HasComment("SKU")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SkuId)
                    .HasColumnName("sku_id")
                    .HasComment("SKUID");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(10,5)")
                    .HasComment("在库重量");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasComment("仓库");
        }
    }
}