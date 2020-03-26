using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_wms_ef.Models
{
    public class TWhBinMapping : IEntityTypeConfiguration<TWhBin>
    {
        public void Configure(EntityTypeBuilder<TWhBin> entity)
        {
            entity.ToTable("t_wh_bin");

                entity.HasComment("物理区域+货区代码+货架号+第几列+第几层+序号");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货位号 货区编号+货位号+货架的列号+货架的层号")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(30)")
                    .HasComment("备注")
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

                entity.Property(e => e.DutyCode)
                    .HasColumnName("duty_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货架代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DutyId)
                    .HasColumnName("duty_id")
                    .HasColumnType("int(11)")
                    .HasComment("货架");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)");

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

                entity.Property(e => e.LocateCode)
                    .HasColumnName("locate_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("位置 地面/货架")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.SizeCode)
                    .HasColumnName("size_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("尺寸 大中小,长宽高")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货架类型 重型/轻型")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasColumnType("int(11)")
                    .HasComment("仓库");

                entity.Property(e => e.X)
                    .IsRequired()
                    .HasColumnName("x")
                    .HasColumnType("varchar(10)")
                    .HasComment("长")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Y)
                    .IsRequired()
                    .HasColumnName("y")
                    .HasColumnType("varchar(10)")
                    .HasComment("宽")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Z)
                    .IsRequired()
                    .HasColumnName("z")
                    .HasColumnType("varchar(10)")
                    .HasComment("高")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ZoneCode)
                    .HasColumnName("zone_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货区代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("货区");
        }
    }
}