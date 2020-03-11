using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInvtCheckDMapping : IEntityTypeConfiguration<TInvtCheckD>
    {
        public void Configure(EntityTypeBuilder<TInvtCheckD> entity)
        {
            entity.ToTable("t_invt_check_d");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键id");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(30)")
                    .HasComment("条码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BinId)
                    .HasColumnName("bin_id")
                    .HasColumnType("int(11)")
                    .HasComment("货位");

                entity.Property(e => e.Carton)
                    .HasColumnName("carton")
                    .HasColumnType("varchar(30)")
                    .HasComment("箱号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("盘点单id");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("修改人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("decimal(10,0)")
                    .HasComment("盘点数量");

                entity.Property(e => e.SkuId)
                    .HasColumnName("sku_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SysQty)
                    .HasColumnName("sys_qty")
                    .HasColumnType("decimal(10,0)")
                    .HasComment("系统数量");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("货区");
        }
    }
}