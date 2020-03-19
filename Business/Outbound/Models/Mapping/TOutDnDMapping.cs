using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class TOutDnDMapping : IEntityTypeConfiguration<TOutDnD>
    {
        public void Configure(EntityTypeBuilder<TOutDnD> entity)
        {
            entity.ToTable("t_out_dn_d");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主键");

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

            entity.Property(e => e.Color)
                .HasColumnName("color")
                .HasColumnType("varchar(30)")
                .HasComment("颜色")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasColumnType("varchar(500)")
                .HasComment("备注")
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

            entity.Property(e => e.HId)
                .HasColumnName("h_id")
                .HasColumnType("bigint(20)")
                .HasComment("发货通知单的ID");

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

            entity.Property(e => e.Product)
                .HasColumnName("product")
                .HasColumnType("varchar(30)")
                .HasComment("款号")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasColumnType("int(11)")
                .HasComment("件数");

            entity.Property(e => e.Size)
                .HasColumnName("size")
                .HasColumnType("varchar(30)")
                .HasComment("尺码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Sku)
                .HasColumnName("sku")
                .HasColumnType("varchar(30)")
                .HasComment("SKU")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Store)
                .HasColumnName("store")
                .HasColumnType("varchar(30)")
                .HasComment("店铺号，单个")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");   

            entity.Property(e=>e.RetailPrice).HasColumnName("retail_price");
            entity.Property(e=>e.ActualPrice).HasColumnName("actual_price");
            entity.Property(e=>e.Discount).HasColumnName("discount");

            entity.HasOne(d => d.TOutDn)
            .WithMany(p => p.DetailList)
            .HasForeignKey(d => d.HId);
        }
    }
}