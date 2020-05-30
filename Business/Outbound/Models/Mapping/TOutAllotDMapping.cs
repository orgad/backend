using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Outbound.Models
{
    public class TOutAllotDMapping : IEntityTypeConfiguration<TOutAllotD>
    {
        public void Configure(EntityTypeBuilder<TOutAllotD> entity)
        {
            entity.ToTable("t_out_allot_d");

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

            entity.Property(e => e.BinCode)
                .HasColumnName("bin_code")
                .HasColumnType("varchar(30)")
                .HasComment("货位码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.BinId)
                .HasColumnName("bin_id")
                .HasColumnType("int(11)")
                .HasComment("货位ID");

            entity.Property(e => e.Carton)
                .HasColumnName("carton")
                .HasColumnType("varchar(30)")
                .HasComment("箱号 整箱库存的箱号")
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
                .HasColumnType("bigint(11)")
                .HasComment("外键");

            entity.Property(e => e.InvtDId)
                .HasColumnName("invt_d_id")
                .HasColumnType("bigint(11)")
                .HasComment("库存明细ID");

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
                .HasComment("匹配数量 系统自动分配的库存");

            entity.Property(e => e.Product)
                .HasColumnName("product")
                .HasColumnType("varchar(30)")
                .HasComment("款号")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasColumnType("int(11)")
                .HasComment("数量 always be 1.;如果是整箱就从箱库存中取整箱的库存数");

            entity.Property(e => e.SkuId)
                .HasColumnName("sku_id")
                .HasColumnType("int(11)");

            entity.Property(e => e.ZoneCode)
                .HasColumnName("zone_code")
                .HasColumnType("varchar(30)")
                .HasComment("货区码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.ZoneId)
                .HasColumnName("zone_id")
                .HasColumnType("int(11)")
                .HasComment("货区ID");

            entity.HasOne(d => d.TOutAllot)
                  .WithMany(p => p.DetailList)
                  .HasForeignKey(d => d.HId);
        }
    }
}