using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Outbound.Models
{
    public class TOutStDeliveryMapping : IEntityTypeConfiguration<TStDelivery>
    {
         public void Configure(EntityTypeBuilder<TStDelivery> entity)
         {
              entity.ToTable("t_st_delivery");

                entity.HasIndex(e => e.HId)
                    .HasName("IDX_T_ST_Delivery_h_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(20)")
                    .HasComment("主键ID");

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

                entity.Property(e => e.ExpressNode)
                    .HasColumnName("express_node")
                    .HasColumnType("varchar(30)")
                    .HasComment("物流节点 下拉, 取t_st_opt的值")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("int(20)")
                    .HasComment("策略ID t_st表的id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasComment("是否删除");

                entity.Property(e => e.IsNeedExpress)
                    .HasColumnName("is_need_express")
                    .HasColumnType("bit(1)")
                    .HasComment("是否需要物流面单");

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

                entity.Property(e => e.OutboundNode)
                    .HasColumnName("outbound_node")
                    .HasColumnType("varchar(30)")
                    .HasComment("发货节点 下拉, 取t_st_opt的值")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
         }
    }
}