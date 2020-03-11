using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInvtMoveMapping : IEntityTypeConfiguration<TInvtMove>
    {
        public void Configure(EntityTypeBuilder<TInvtMove> entity)
        {
            entity.ToTable("t_invt_move");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.Barcode)
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

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("移货单号，前缀MVT")
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

                entity.Property(e => e.DownStatus)
                    .HasColumnName("down_status")
                    .HasColumnType("varchar(30)")
                    .HasComment("下架状态:未处理/处理中/已处理")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FromBinCode)
                    .HasColumnName("from_bin_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("来源货位代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FromBinId)
                    .HasColumnName("from_bin_id")
                    .HasColumnType("int(11)")
                    .HasComment("来源货位");

                entity.Property(e => e.FromZoneCode)
                    .HasColumnName("from_zone_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("来源货区代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FromZoneId)
                    .HasColumnName("from_zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("来源货区");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("移货计划的ID，可以为空。为空表示没有移货计划");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'FALSE'");

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
                    .HasColumnType("decimal(10,0)")
                    .HasComment("移货数量");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SkuId)
                    .HasColumnName("sku_id")
                    .HasColumnType("int(11)")
                    .HasComment("SKU");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(30)")
                    .HasComment("单据状态(未处理None,已完成:Finished)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ToBinCode)
                    .HasColumnName("to_bin_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("目的货位代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ToBinId)
                    .HasColumnName("to_bin_id")
                    .HasColumnType("int(11)")
                    .HasComment("目的货位");

                entity.Property(e => e.ToZoneCode)
                    .HasColumnName("to_zone_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("目的货区代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ToZoneId)
                    .HasColumnName("to_zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("目的货区");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("业务类型，区分批量移货Batch/直接移货Direct")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpStatus)
                    .HasColumnName("up_status")
                    .HasColumnType("varchar(30)")
                    .HasComment("上架状态:未处理/处理中/已处理")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasColumnType("int(11)")
                    .HasComment("仓库ID");
        }
    }
}