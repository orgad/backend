using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInvtCheckMapping : IEntityTypeConfiguration<TInvtCheck>
    {
        public void Configure(EntityTypeBuilder<TInvtCheck> entity)
        {
            entity.ToTable("t_invt_check");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键ID");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("盘点计划编号")
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

                entity.Property(e => e.GoodsType)
                    .HasColumnName("goods_type")
                    .HasColumnType("varchar(30)")
                    .HasComment("货物类型 物料/商品 Mat/Prod")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

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

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("盘点类型 盲盘/明盘")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeMode)
                    .HasColumnName("type_mode")
                    .HasColumnType("varchar(30)")
                    .HasComment("盘点方式 ByCustomer,BySKU,ByZone,ByDuty,ByBin")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasColumnType("int(11)")
                    .HasComment("仓库");
        }
    }
}