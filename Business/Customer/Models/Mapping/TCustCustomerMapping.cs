using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TCustCustomerMapping : IEntityTypeConfiguration<TCustCustomer>
    {
        public void Configure(EntityTypeBuilder<TCustCustomer> entity)
        {
            entity.ToTable("t_cust_customer");

                entity.HasComment("客户");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(200)")
                    .HasComment("地址")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(20)")
                    .HasComment("代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasColumnType("varchar(50)")
                    .HasComment("联系人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("修改人")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NameCn)
                    .HasColumnName("name_cn")
                    .HasColumnType("varchar(50)")
                    .HasComment("中文名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Tel)
                    .HasColumnName("tel")
                    .HasColumnType("varchar(50)")
                    .HasComment("电话")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
        }
    }
}