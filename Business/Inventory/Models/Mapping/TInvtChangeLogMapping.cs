using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInvtChangeLogMapping : IEntityTypeConfiguration<TInvtChangeLog>
    {
        public void Configure(EntityTypeBuilder<TInvtChangeLog> entity)
        {
            entity.ToTable("t_invt_change_log");

            entity.HasComment("记录对在库库存有影响的库存变化 入库,出库,退货,退仓,调整");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasComment("主键ID");

            entity.Property(e => e.Barcode)
                .HasColumnName("barcode")
                .HasColumnType("varchar(30)")
                .HasComment("条码")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.BinId)
                .HasColumnName("bin_id")
                .HasComment("货位ID");

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

            entity.Property(e => e.CustId)
                .HasColumnName("cust_id")
                .HasComment("客户");

            entity.Property(e => e.InvtDId)
                .HasColumnName("invt_d_id")
                .HasComment("库存明细ID 库存明细表的id");

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

            entity.Property(e => e.OrderId)
                .HasColumnName("order_id")
                .HasComment("单据id 记录是那个单据触发的库存操作");

            entity.Property(e => e.OrderType)
                .HasColumnName("order_type")
                .HasColumnType("varchar(30)")
                .HasComment("单据类型")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasComment("数量 入库为正,出库为负");

            entity.Property(e => e.SkuId)
                .HasColumnName("sku_id")
                .HasComment("SKU");

            entity.Property(e => e.WhId)
                .HasColumnName("wh_id")
                .HasComment("仓库");

            entity.Property(e => e.ZoneId)
                .HasColumnName("zone_id")
                .HasComment("货区ID");
        }
    }
}