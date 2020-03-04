using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_wms_ef.Models
{
    public partial class wmswarehouseContext : DbContext
    {
        public wmswarehouseContext()
        {
        }

        public wmswarehouseContext(DbContextOptions<wmswarehouseContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<TWhVirtual> TWhVirtual { get; set; }
        public virtual DbSet<TWhWarehouse> TWhWarehouse { get; set; }
       
        public virtual DbSet<TWhZonetype> TWhZonetype { get; set; }

        public virtual DbSet<TWhZone> TWhZones { get; set; }
        
        public virtual DbSet<TWhDutyracking> TWhDutyracking { get; set; }

        public virtual DbSet<TWhBin> TWhBins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                */
                //optionsBuilder.UseMySql("server=rm-uf619rka9ffv70g6rbo.mysql.rds.aliyuncs.com;port=3306;database=wms-warehouse;user=wms;password=R9Ayn6Jv52", x => x.ServerVersion("8.0.16-mysql"));
                optionsBuilder.UseMySql(DbConfig.WarehouseDb, x => x.ServerVersion("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TWhBin>(entity =>
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
            });

            modelBuilder.Entity<TWhDutyracking>(entity =>
            {
                entity.ToTable("t_wh_dutyracking");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键ID");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货架号")
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

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("货区");
            });

            modelBuilder.Entity<TWhVirtual>(entity =>
            {
                entity.ToTable("t_wh_virtual");

                entity.HasComment("虚拟仓设置");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BinCode)
                    .HasColumnName("bin_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货位")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BinId)
                    .HasColumnName("bin_id")
                    .HasColumnType("int(11)")
                    .HasComment("货位");

                entity.Property(e => e.BrandCode)
                    .HasColumnName("brand_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("品牌")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)")
                    .HasComment("品牌");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("创建人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.CustCode)
                    .HasColumnName("cust_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("客户")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CustId)
                    .HasColumnName("cust_id")
                    .HasColumnType("int(11)")
                    .HasComment("客户");

                entity.Property(e => e.DutyCode)
                    .HasColumnName("duty_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货架")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DutyId)
                    .HasColumnName("duty_id")
                    .HasColumnType("int(11)")
                    .HasComment("货架");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(30)")
                    .HasComment("修改人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasColumnType("int(11)")
                    .HasComment("仓库");

                entity.Property(e => e.ZoneCode)
                    .HasColumnName("zone_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货区")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZoneId)
                    .HasColumnName("zone_id")
                    .HasColumnType("int(11)")
                    .HasComment("货区");
            });

            modelBuilder.ApplyConfiguration(new TWhWarehouseMapping());

            modelBuilder.Entity<TWhZone>(entity =>
            {
                entity.ToTable("t_wh_zone");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(30)")
                    .HasComment("描述")
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

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(30)")
                    .HasComment("货区类型")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasColumnType("int(11)")
                    .HasComment("仓库");
            });

            modelBuilder.Entity<TWhZonetype>(entity =>
            {
                entity.ToTable("t_wh_zonetype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("代码")
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

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)");

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

                entity.Property(e => e.NameCn)
                    .HasColumnName("name_cn")
                    .HasColumnType("varchar(100)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);           
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
