using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_wms_ef.Business.Models;

namespace dotnet_wms_ef
{
    public class TOutDMapping : IEntityTypeConfiguration<TOutD>
    {
        public void Configure(EntityTypeBuilder<TOutD> entity)
        {
            entity.ToTable("t_out_d");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)");

            entity.Property(e => e.Barcode)
                .IsRequired()
                .HasColumnName("barcode")
                .HasColumnType("varchar(30)")
                .HasComment("条码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Carton)
                .HasColumnName("carton")
                .HasColumnType("varchar(50)")
                .HasComment("箱号")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Color)
                .HasColumnName("color")
                .HasColumnType("varchar(20)")
                .HasComment("颜色")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasColumnType("varchar(30)")
                .HasComment("备注")
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
                .HasColumnType("bigint(20)");

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

            entity.Property(e => e.MatchingQty)
                .HasColumnName("matching_qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'0'")
                .HasComment("分配数量");

            entity.Property(e => e.Product)
                .HasColumnName("product")
                .HasColumnType("varchar(30)")
                .HasComment("款号")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasColumnType("int(11)")
                .HasComment("数量");

            entity.Property(e => e.Size)
                .HasColumnName("size")
                .HasColumnType("varchar(20)")
                .HasComment("尺码")
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
                .HasColumnType("int(20)")
                .HasComment("SKU");

            entity.Property(e => e.RetailPrice).HasColumnName("retail_price");
            entity.Property(e => e.ActualPrice).HasColumnName("actual_price");
            entity.Property(e => e.Discount).HasColumnName("discount");

            entity.HasOne(d => d.TOut)
                  .WithMany(p => p.DetailList)
                  .HasForeignKey(d => d.HId);
        }
    }
}