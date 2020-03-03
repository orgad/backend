using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInCheckMapping : IEntityTypeConfiguration<TInCheck>
    {
        public void Configure(EntityTypeBuilder<TInCheck> entity)
        {
            entity.ToTable("t_in_check");

                entity.HasComment("验货单");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.CartonQty)
                    .HasColumnName("carton_qty")
                    .HasColumnType("int(11)")
                    .HasComment("完好箱数 完好箱数");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("验货单号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建时间");

                entity.Property(e => e.DamageCartonQty)
                    .HasColumnName("damage_carton_qty")
                    .HasColumnType("int(11)")
                    .HasComment("破损箱数 破损箱数");

                entity.Property(e => e.DamageQty)
                    .HasColumnName("damage_qty")
                    .HasColumnType("int(11)")
                    .HasComment("破损箱件数 破损箱件数");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("外键");

                entity.Property(e => e.IsCiq)
                    .HasColumnName("is_ciq")
                    .HasColumnType("bit(1)")
                    .HasComment("是否有CIQ");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
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
                    .HasComment("完好件数 完好件数");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(30)")
                    .HasComment("这里的值与asn的验货状态一致")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
        }
    }
}