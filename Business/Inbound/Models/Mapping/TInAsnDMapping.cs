using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TInAsnDMapping : IEntityTypeConfiguration<TInAsnD>
    {
        public void Configure(EntityTypeBuilder<TInAsnD> entity)
        {
            entity.ToTable("t_in_asn_d");

            entity.HasComment("到货通知单明细");

            entity.HasIndex(e => e.Barcode)
                .HasName("IDX_T_In_ASN_D_Barcode");

            entity.HasIndex(e => e.Carton)
                .HasName("IDX_T_In_ASN_D_Carton");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("bigint(20)")
                .HasComment("主键");

            entity.Property(e => e.Barcode)
                .HasColumnName("barcode")
                .HasColumnType("varchar(30)")
                .HasComment("条码 如果有SKUNo，就存SKUNo，如果没有，就存Barcode")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Carton)
                .HasColumnName("carton")
                .HasColumnType("varchar(100)")
                .HasComment("箱号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ColorCode)
                .HasColumnName("color_code")
                .HasColumnType("varchar(20)")
                .HasComment("颜色代码")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ColorNameEn)
                .HasColumnName("color_name_en")
                .HasColumnType("varchar(20)")
                .HasComment("颜色英文")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ColorNameLc)
                .HasColumnName("color_name_lc")
                .HasColumnType("varchar(50)")
                .HasComment("颜色中文")
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

            entity.Property(e => e.DeclarationPrice)
                .HasColumnName("declaration_price")
                .HasComment("申报价格");

            entity.Property(e => e.Dimension)
                .HasColumnName("dimension")
                .HasColumnType("varchar(50)")
                .HasComment("箱型 长*宽*高")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Gender)
                .HasColumnName("gender")
                .HasColumnType("varchar(1)")
                .HasComment("性别")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

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

            entity.Property(e => e.OriginEn)
                .HasColumnName("origin_en")
                .HasColumnType("varchar(20)")
                .HasComment("产地")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.OriginLc)
                .HasColumnName("origin_lc")
                .HasColumnType("varchar(50)")
                .HasComment("产地中文")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ProductCode)
                .HasColumnName("product_code")
                .HasColumnType("varchar(30)")
                .HasComment("款号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ProductNameEn)
                .HasColumnName("product_name_en")
                .HasColumnType("varchar(30)")
                .HasComment("英文名称")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ProductNameLc)
                .HasColumnName("product_name_lc")
                .HasColumnType("varchar(50)")
                .HasComment("简称")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ProductType)
                .HasColumnName("product_type")
                .HasColumnType("varchar(10)")
                .HasComment("货物类型 产品类型")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.ProductionDate)
                .HasColumnName("production_date")
                .HasColumnType("datetime")
                .HasComment("生产日期");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasColumnType("int(11)")
                .HasComment("数量");

            entity.Property(e => e.RetailPrice)
                .HasColumnName("retail_price")
                .HasComment("零售价格");

            entity.Property(e => e.SafeClass)
                .HasColumnName("safe_class")
                .HasColumnType("varchar(30)")
                .HasComment("安全等级")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Season)
                .HasColumnName("season")
                .HasColumnType("varchar(20)")
                .HasComment("季节")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.SizeCode)
                .HasColumnName("size_code")
                .HasColumnType("varchar(20)")
                .HasComment("尺寸")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.SizeEn)
                .HasColumnName("size_en")
                .HasColumnType("varchar(20)")
                .HasComment("尺寸英文")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.SizeLc)
                .HasColumnName("size_lc")
                .HasColumnType("varchar(50)")
                .HasComment("尺寸中文")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Sku)
                .HasColumnName("sku")
                .HasColumnType("varchar(30)")
                .HasComment("SKU编号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.StandardCode)
                .HasColumnName("standard_code")
                .HasColumnType("varchar(30)")
                .HasComment("执行标准")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Store)
                .HasColumnName("store")
                .HasColumnType("varchar(50)")
                .HasComment("门店")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.HasOne(d => d.TInAsn)
                .WithMany(p => p.DetailList)
                .HasForeignKey(d => d.HId);
        }
    }
}