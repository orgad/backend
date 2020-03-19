using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class TOutExpressMapping : IEntityTypeConfiguration<TOutExpress>
    {
         public void Configure(EntityTypeBuilder<TOutExpress> entity)
         {
             entity.ToTable("t_out_express");

                entity.HasIndex(e => e.Code)
                    .HasName("IDU_T_Out_Express_code")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("面单号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.Courier)
                    .HasColumnName("courier")
                    .HasColumnType("varchar(30)")
                    .HasComment("承运商")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.DestCityCode)
                    .HasColumnName("dest_city_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("面单的区域信息 接口返回的信息")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.ExpressOrderId)
                    .HasColumnName("express_order_id")
                    .HasColumnType("varchar(58)")
                    .HasComment("面单请求id 仓库+客户代码+单号+流水号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.ExpressPages)
                    .HasColumnName("express_pages")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("子单数量 根据箱数自动默认产生，如10箱，母单+子单一共是10");

                entity.Property(e => e.ExpressTrackingNo)
                    .HasColumnName("express_tracking_no")
                    .HasColumnType("varchar(30)")
                    .HasComment("面单号 接口返回的信息")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("是否删除");

                entity.Property(e => e.IsPrintExpress)
                    .HasColumnName("is_print_express")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'")
                    .HasComment("面单是否已打印");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("修改人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.OutboundCode)
                    .HasColumnName("outbound_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("出库单号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.OutboundId)
                    .HasColumnName("outbound_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("出库单Id");
         }
    }
}