using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInCheckDMapping : IEntityTypeConfiguration<TInCheckD>
    {
        public void Configure(EntityTypeBuilder<TInCheckD> entity)
        {
             entity.ToTable("t_in_check_d");

                entity.HasComment("验货单明细");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(30)")
                    .HasComment("条码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Carton)
                    .HasColumnName("carton")
                    .HasColumnType("varchar(30)")
                    .HasComment("破损箱号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment1)
                    .HasColumnName("comment1")
                    .HasColumnType("varchar(200)")
                    .HasComment("破损描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment2)
                    .HasColumnName("comment2")
                    .HasColumnType("varchar(200)")
                    .HasComment("破损描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment3)
                    .HasColumnName("comment3")
                    .HasColumnType("varchar(200)")
                    .HasComment("破损描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment4)
                    .HasColumnName("comment4")
                    .HasColumnType("varchar(200)")
                    .HasComment("破损描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment5)
                    .HasColumnName("comment5")
                    .HasColumnType("varchar(200)")
                    .HasComment("破损描述")
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

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("外键");

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

                entity.Property(e => e.Photo1)
                    .HasColumnName("photo1")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片1 破损照片1")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo2)
                    .HasColumnName("photo2")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片2 破损照片2")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo3)
                    .HasColumnName("photo3")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片3 破损照片3")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo4)
                    .HasColumnName("photo4")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片4 破损照片4")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo5)
                    .HasColumnName("photo5")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片5 破损照片5")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e=>e.SkuId).HasColumnName("sku_id");

                entity.Property(e => e.Sku)
                    .HasColumnName("sku")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(20)")
                    .HasComment("验货类型 破损报告/CIQ验货")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
        }
    }
}