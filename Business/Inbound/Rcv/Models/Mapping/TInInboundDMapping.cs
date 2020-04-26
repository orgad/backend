using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInInboundDMapping : IEntityTypeConfiguration<TInInboundD>
    {
        public void Configure(EntityTypeBuilder<TInInboundD> entity)
        {
            entity.ToTable("t_in_inbound_d");

            entity.HasComment("入库单明细 扫描生成");

            entity.HasIndex(e => e.Barcode)
                .HasName("IDX_T_In_Ind_D_BarcodeF8C6");

            entity.HasIndex(e => e.Carton)
                .HasName("IDX_T_In_Inbound_D_Carton");

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
                .HasComment("箱号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.Comment)
                .HasColumnName("comment")
                .HasColumnType("varchar(200)")
                .HasComment("备注")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.HId)
                .HasColumnName("h_id")
                .HasColumnType("bigint(20)")
                .HasComment("外键");

            entity.Property(e => e.Qty)
                .HasColumnName("qty")
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'1'")
                .HasComment("数量");

            entity.Property(e => e.Sku)
                .HasColumnName("sku")
                .HasColumnType("varchar(30)")
                .HasComment("SKU")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");

            entity.Property(e => e.SkuId)
                .HasColumnName("sku_id")
                .HasColumnType("bigint(20)")
                .HasComment("商品ID");

            entity.Property(e => e.Store)
                .HasColumnName("store")
                .HasColumnType("varchar(30)")
                .HasComment("店铺号")
                .HasCharSet("utf8")
                .HasCollation("utf8_general_ci");
            
            entity.Property(e => e.QcCode).HasColumnName("qc_code");

            entity.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .HasColumnType("bit(1)")
                .HasDefaultValueSql("b'0'");

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


            entity.HasOne(d => d.TInInbound)
                  .WithMany(p => p.DetailList)
                  .HasForeignKey(d => d.HId);
        }
    }
}