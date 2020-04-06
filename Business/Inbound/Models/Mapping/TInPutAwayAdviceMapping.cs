using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Inbound.Models
{
     public class TInPutAwayAdviceMapping : IEntityTypeConfiguration<TInPutawayAdvice>
    {
        public void Configure(EntityTypeBuilder<TInPutawayAdvice> entity)
        {
            
                 entity.ToTable("t_in_putaway_advice");

                entity.HasComment("上架建议");

                entity.HasIndex(e => e.AdvBinCode)
                    .HasName("IDX_T_In_Puice_AdvBinCode4B97");

                entity.HasIndex(e => e.Barcode)
                    .HasName("IDX_T_In_Puice_Barcode57EF");

                entity.HasIndex(e => e.Carton)
                    .HasName("IDX_T_In_Puice_Carton3FC4");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键");

                entity.Property(e => e.AdvBinCode)
                    .HasColumnName("adv_bin_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("建议库位号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdvZoneCode)
                    .HasColumnName("adv_zone_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("建议库区号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(50)")
                    .HasComment("条码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BinCode)
                    .HasColumnName("bin_code")
                    .HasColumnType("varchar(50)")
                    .HasComment("实际库位")
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
                    .HasColumnType("varchar(500)")
                    .HasComment("备注")
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

                entity.Property(e => e.InboundId)
                    .HasColumnName("inbound_id")
                    .HasColumnType("int(11)")
                    .HasComment("入库单ID");

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
        }
    }
}