using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TOutStAlotMapping : IEntityTypeConfiguration<TStAllot>
    {
        public void Configure(EntityTypeBuilder<TStAllot> entity)
        {
            entity.ToTable("t_st_allot");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int(11)")
                .HasComment("主键");

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
                .HasColumnType("int(11)")
                .HasComment("策略id,t_st表的id");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'");

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

            entity.Property(e => e.OrderBy)
                .HasColumnName("order_by")
                .HasColumnType("varchar(30)")
                .HasComment("优先级(Asc,Desc)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");

            entity.Property(e => e.Seq)
                .HasColumnName("seq")
                .HasColumnType("int(11)")
                .HasComment("执行顺序 按顺序从大到小执行(数字)");

            entity.Property(e => e.TypeCode)
                .HasColumnName("type_code")
                .HasColumnType("varchar(30)")
                .HasComment("分配规则 按库存(ByInvtQty),按货位优先级(ByBin),按入库时间(ByRcvDate)")
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_0900_ai_ci");
        }
    }
}