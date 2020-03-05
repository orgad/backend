using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInStRcvMapping : IEntityTypeConfiguration<TStRcv>
    {
        public void Configure(EntityTypeBuilder<TStRcv> entity)
        {
             entity.ToTable("t_st_rcv");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowBlind)
                    .HasColumnName("allow_blind")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.AllowOut)
                    .HasColumnName("allow_out")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.BackNode)
                    .HasColumnName("back_node")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CheckList)
                    .HasColumnName("check_list")
                    .HasColumnType("varchar(400)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.OutRate).HasColumnName("out_rate");
        }
    }
}