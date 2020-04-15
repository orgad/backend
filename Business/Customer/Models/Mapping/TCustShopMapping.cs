using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TCustShopMapping : IEntityTypeConfiguration<TCustShop>
    {
        public void Configure(EntityTypeBuilder<TCustShop> entity)
        {
            entity.ToTable("t_cust_shop");

                entity.HasComment("门店");

                entity.HasIndex(e => e.CustId)
                    .HasName("fk_brand_cust_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(20)")
                    .HasComment("店铺代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasColumnType("varchar(30)")
                    .HasComment("联系人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

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

                entity.Property(e => e.CustId)
                    .HasColumnName("cust_id")
                    .HasColumnType("int(11)")
                    .HasComment("客户id");

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

                entity.Property(e => e.NameEn)
                    .HasColumnName("name_en")
                    .HasColumnType("varchar(200)")
                    .HasComment("品牌名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NameCn)
                    .HasColumnName("name_cn")
                    .HasColumnType("varchar(200)")
                    .HasComment("品牌中文名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasColumnType("varchar(30)")
                    .HasComment("联系电话")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.TCustShop)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("fk_brand_cust_id");
        }
    }
}