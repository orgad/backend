using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_wms_ef.Business.Models;

namespace dotnet_wms_ef
{
    public class TOutCheckMapping : IEntityTypeConfiguration<TOutCheck>
    {
         public void Configure(EntityTypeBuilder<TOutCheck> entity)
         {
             entity.ToTable("t_out_check");

                entity.HasComment("复核单");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.CartonQty)
                    .HasColumnName("carton_qty")
                    .HasColumnType("int(11)")
                    .HasComment("箱数");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("单号")
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

                entity.Property(e => e.FirstScanAt)
                    .HasColumnName("first_scan_at")
                    .HasColumnType("datetime")
                    .HasComment("首次扫描时间");

                entity.Property(e => e.IsCancel)
                    .HasColumnName("is_cancel")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("是否取消");

                entity.Property(e => e.IsConfirm)
                    .HasColumnName("is_confirm")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("是否确认");

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

                entity.Property(e => e.LastScanAt)
                    .HasColumnName("last_scan_at")
                    .HasColumnType("datetime")
                    .HasComment("最后扫描时间");

                entity.Property(e => e.OutboundId)
                    .HasColumnName("outbound_id")
                    .HasColumnType("int(11)")
                    .HasComment("出库单号");

                entity.Property(e => e.Qty)
                    .HasColumnName("qty")
                    .HasColumnType("int(11)")
                    .HasComment("数量");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Store)
                    .HasColumnName("store")
                    .HasColumnType("varchar(30)")
                    .HasComment("店铺")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
         }
    }
}