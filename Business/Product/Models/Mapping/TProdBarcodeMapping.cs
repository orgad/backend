using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Product.Models
{
    public class TProdBarcodeMapping:IEntityTypeConfiguration<TProdBarcode>
    {
        public void Configure(EntityTypeBuilder<TProdBarcode> entity)
        {
            entity.ToTable("t_prod_barcode");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("主键");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(20)")
                    .HasComment("条码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
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

                entity.Property(e => e.SkuId).HasColumnName("sku_id");
        }
    }
}