using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInvtUnfreezeMapping : IEntityTypeConfiguration<TInvtUnfreeze>
    {
        public void Configure(EntityTypeBuilder<TInvtUnfreeze> entity)
        {
             entity.ToTable("t_invt_unfreeze");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(30)")
                    .HasComment("条码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BinCode)
                    .HasColumnName("bin_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("库位号 库位id的冗余字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BinId)
                    .HasColumnName("bin_id")
                    .HasColumnType("int(11)")
                    .HasComment("货位id");

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

                entity.Property(e => e.FreezeId)
                    .HasColumnName("freeze_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("冻结单id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasComment("是否删除");

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
                    .HasColumnType("int(11)")
                    .HasComment("冻结数量");

                entity.Property(e => e.ReasonCode)
                    .HasColumnName("reason_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("解冻原因")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasColumnType("varchar(100)")
                    .HasComment("sku_id的冗余字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SkuId)
                    .HasColumnName("sku_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ZoneCode)
                    .HasColumnName("zone_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("库区号 货区id的冗余字段")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("货区id");
        }
    }
}