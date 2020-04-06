using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Outbound.Models
{
    public class TOutAddressMapping : IEntityTypeConfiguration<TOutAddress>
    {
         public void Configure(EntityTypeBuilder<TOutAddress> entity)
         {
             entity.ToTable("t_out_address");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("编号 主键");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasColumnType("varchar(500)")
                    .HasComment("详细地址 详细地址")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(30)")
                    .HasComment("市 市名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CityCode)
                    .HasColumnName("city_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("市代码 市代码，数字编码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(10)")
                    .HasComment("地址代码 地址码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasColumnType("varchar(30)")
                    .HasComment("联系人 联系人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("创建人 创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间 创建时间");

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasColumnType("varchar(30)")
                    .HasComment("区县 区县名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DistrictCode)
                    .HasColumnName("district_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("区县代码 区县代码，数字编码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("修改人 修改人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间 修改时间");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasColumnType("varchar(30)")
                    .HasComment("手机 手机")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NameCn)
                    .HasColumnName("name_cn")
                    .HasColumnType("varchar(30)")
                    .HasComment("中文名称 中文名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasColumnType("varchar(30)")
                    .HasComment("英文名称 英文名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .HasColumnType("varchar(30)")
                    .HasComment("省 省名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProvinceCode)
                    .HasColumnName("province_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("省代码 省代码，数字编码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasColumnType("varchar(30)")
                    .HasComment("电话 座机")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Town)
                    .HasColumnName("town")
                    .HasColumnType("varchar(30)")
                    .HasComment("村镇 村镇名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TownCode)
                    .HasColumnName("town_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("村镇代码 村镇代码，数字编码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("int(11)")
                    .HasComment("分类 仓库WH/门店Store/电商EC/消费者Consumer");
         }
    }
}