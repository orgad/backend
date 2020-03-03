using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
     public class TInQcDMapping : IEntityTypeConfiguration<TInQcD>
    {
        public void Configure(EntityTypeBuilder<TInQcD> entity)
        {
             entity.ToTable("t_in_qc_d");

                entity.HasComment("质检扫描记录");

                entity.HasIndex(e => e.Barcode)
                    .HasName("IDX_T_In_QC_D_Barcode");

                entity.HasIndex(e => e.Carton)
                    .HasName("IDX_T_In_QC_D_Carton");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(50)")
                    .HasComment("条码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Carton)
                    .HasColumnName("carton")
                    .HasColumnType("varchar(50)")
                    .HasComment("箱号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment1)
                    .HasColumnName("comment1")
                    .HasColumnType("varchar(200)")
                    .HasComment("质检描述 文字描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment2)
                    .HasColumnName("comment2")
                    .HasColumnType("varchar(200)")
                    .HasComment("质检描述 质检描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Comment3)
                    .HasColumnName("comment3")
                    .HasColumnType("varchar(200)")
                    .HasComment("质检描述 质检描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建日期")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("创建人");

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
                    .HasComment("照片2 破损照片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo2)
                    .HasColumnName("photo2")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片3 破损照片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo3)
                    .HasColumnName("photo3")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片4 破损照片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photoa)
                    .HasColumnName("photoa")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片 价签照片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photob)
                    .HasColumnName("photob")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片1 全景照片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.QcCode)
                    .HasColumnName("qc_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("质检结果 良品Good/不良品Damage")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SkuId)
                    .HasColumnName("sku_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("商品ID");
        }
    }
}