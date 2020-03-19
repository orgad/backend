using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class TOutWaveMapping : IEntityTypeConfiguration<TOutWave>
    {
         public void Configure(EntityTypeBuilder<TOutWave> entity)
         {
             entity.ToTable("t_out_wave");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("波次单号 WAV2019110100000001")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("修改人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("int(11)")
                    .HasComment("拣货单数量");

                entity.Property(e => e.SkuCatQty)
                    .HasColumnName("sku_cat_qty")
                    .HasColumnType("int(11)")
                    .HasComment("SKU品种数");

                entity.Property(e => e.SkuQty)
                    .HasColumnName("sku_qty")
                    .HasColumnType("int(11)")
                    .HasComment("SKU总数");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasColumnType("int(11)")
                    .HasComment("仓库ID");
         }
    }
}