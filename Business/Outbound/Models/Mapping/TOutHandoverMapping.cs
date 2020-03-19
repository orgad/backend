using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class TOutHandoverMapping : IEntityTypeConfiguration<TOutHandover>
    {
         public void Configure(EntityTypeBuilder<TOutHandover> entity)
         {
             entity.ToTable("t_out_handover");

                entity.HasComment("交接单");

                entity.HasIndex(e => e.Code)
                    .HasName("code_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("外键")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("''")
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

                entity.Property(e => e.CustId)
                    .HasColumnName("cust_id")
                    .HasColumnType("int(11)")
                    .HasComment("客户");

                entity.Property(e => e.Driver)
                    .HasColumnName("driver")
                    .HasColumnType("varchar(100)")
                    .HasComment("司机")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsConfirm)
                    .HasColumnName("is_confirm")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("是否确认 表示交接扫描是否完成");

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

                entity.Property(e => e.PlateNo)
                    .HasColumnName("plate_no")
                    .HasColumnType("varchar(100)")
                    .HasComment("车牌 license plate number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ShippedDate)
                    .HasColumnName("shipped_date")
                    .HasColumnType("datetime")
                    .HasComment("发运时间 离仓日期");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Store)
                    .HasColumnName("store")
                    .HasColumnType("varchar(50)")
                    .HasComment("门店")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
         }
    }
}