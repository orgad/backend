using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class TOutHandoverDMapping : IEntityTypeConfiguration<TOutHandoverD>
    {
         public void Configure(EntityTypeBuilder<TOutHandoverD> entity)
         {
             entity.ToTable("t_out_handover_d");

                entity.HasComment("交接单明细");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Carton)
                    .IsRequired()
                    .HasColumnName("carton")
                    .HasColumnType("varchar(30)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Courier)
                    .HasColumnName("courier")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpressNo)
                    .HasColumnName("express_no")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pallet)
                    .IsRequired()
                    .HasColumnName("pallet")
                    .HasColumnType("varchar(30)")
                    .HasDefaultValueSql("''")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
         }
    }
}