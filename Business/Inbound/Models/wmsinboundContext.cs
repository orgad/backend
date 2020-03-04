using System;
using Microsoft.EntityFrameworkCore;

namespace dotnet_wms_ef.Models
{
    public partial class wmsinboundContext : DbContext
    {
        public wmsinboundContext()
        {
        }

        public wmsinboundContext(DbContextOptions<wmsinboundContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TInAsn> TInAsns { get; set; }
        public virtual DbSet<TInAsnCiq> TInAsnCiq { get; set; }
        public virtual DbSet<TInAsnD> TInAsnDs { get; set; }
        public virtual DbSet<TInCheck> TInChecks { get; set; }
        public virtual DbSet<TInCheckD> TInCheckDs { get; set; }
        public virtual DbSet<TInInbound> TInInbounds { get; set; }
        public virtual DbSet<TInInboundD> TInInboundDs { get; set; }
        public virtual DbSet<TInOptlog> TInOptlogs { get; set; }
        public virtual DbSet<TInQc> TInQcs { get; set; }
        public virtual DbSet<TInQcD> TInQcDs { get; set; }
        public virtual DbSet<TInPutawayAdvice> TInPutawayAdvice { get; set; }
        public virtual DbSet<TInPutaway> TInPutaways { get; set; }
        public virtual DbSet<TInPutawayD> TInPutawayDs { get; set; }
        public virtual DbSet<TInValue> TInValue { get; set; }
        public virtual DbSet<TInLog> TInLog { get; set; }
        public virtual DbSet<TSt> TSt { get; set; }
        public virtual DbSet<TStD> TStD { get; set; }
        public virtual DbSet<TStOpt> TStOpt { get; set; }
        public virtual DbSet<TStRcv> TStRcv { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
*/
                optionsBuilder.UseMySql(DbConfig.InboundDb, x => x.ServerVersion("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TInAsnMapping());
            modelBuilder.ApplyConfiguration(new TInAsnCiqMapping());
            modelBuilder.ApplyConfiguration(new TInAsnDMapping());
            modelBuilder.ApplyConfiguration(new TInCheckMapping());
            modelBuilder.ApplyConfiguration(new TInCheckDMapping());
            modelBuilder.ApplyConfiguration(new TInInboundMapping());
            modelBuilder.ApplyConfiguration(new TInInboundDMapping());
            modelBuilder.ApplyConfiguration(new TInOptLogMapping());
            modelBuilder.ApplyConfiguration(new TInQcMapping());
            modelBuilder.ApplyConfiguration(new TInQcDMapping());
            modelBuilder.ApplyConfiguration(new TInPutAwayMapping());
            modelBuilder.ApplyConfiguration(new TInPutAwayDMapping());

            modelBuilder.Entity<TInLog>(entity =>
            {
                entity.ToTable("t_in_log");

                entity.HasComment("入库单据日志");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键ID");

                entity.Property(e => e.CreatedBy)
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

                entity.Property(e => e.OptCode)
                    .HasColumnName("opt_code")
                    .HasColumnType("varchar(50)")
                    .HasComment("操作代码 新增/修改/删除/查询/打印/导出")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("单据ID");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("varchar(50)")
                    .HasComment("操作内容-原始 来源")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Target)
                    .HasColumnName("target")
                    .HasColumnType("varchar(50)")
                    .HasComment("操作内容-目标 目标")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

               
            });

            modelBuilder.Entity<TInValue>(entity =>
            {
                entity.ToTable("t_in_value");

                entity.HasComment("增值服务");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)")
                    .HasComment("主键");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasColumnType("varchar(50)")
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
                    .HasComment("创建日期");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("外键");

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

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片 价签照片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Photo1)
                    .HasColumnName("photo1")
                    .HasColumnType("varchar(500)")
                    .HasComment("照片1 全景照片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("varchar(50)")
                    .HasComment("尺码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SkuId)
                    .HasColumnName("sku_id")
                    .HasColumnType("int(11)")
                    .HasComment("SKUID");
            });

            modelBuilder.Entity<TSt>(entity =>
            {
                entity.ToTable("t_st");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)")
                    .HasComment("品牌 ");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(30)")
                    .HasComment("代码 ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("创建人 ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间 ");

                entity.Property(e => e.CustId)
                    .HasColumnName("cust_id")
                    .HasColumnType("int(11)")
                    .HasComment("客户 ");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
                    .HasComment("修改人 ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime")
                    .HasComment("修改时间 ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasComment("名称 ")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.WhId)
                    .HasColumnName("wh_id")
                    .HasColumnType("int(11)")
                    .HasComment("仓库 ");
            });

            modelBuilder.Entity<TStD>(entity =>
            {
                entity.ToTable("t_st_d");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .HasComment("主键");

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

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("int(11)")
                    .HasComment("策略ID");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

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

                entity.Property(e => e.OptCode)
                    .IsRequired()
                    .HasColumnName("opt_code")
                    .HasColumnType("varchar(20)")
                    .HasComment("操作代码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Seq)
                    .HasColumnName("seq")
                    .HasColumnType("int(11)")
                    .HasComment("操作顺序");
            });

            modelBuilder.Entity<TStOpt>(entity =>
            {
                entity.ToTable("t_st_opt");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

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
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

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
                    .HasColumnName("name")
                    .HasColumnType("varchar(30)")
                    .HasComment("名称")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("type_code")
                    .HasColumnType("varchar(100)")
                    .HasComment("业务类型")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TStRcv>(entity =>
            {
                entity.ToTable("t_st_rcv");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AllowBlind)
                    .HasColumnName("allow_blind")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.AllowOut)
                    .HasColumnName("allow_out")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.BackNode)
                    .HasColumnName("back_node")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CheckList)
                    .HasColumnName("check_list")
                    .HasColumnType("varchar(400)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.HId)
                    .HasColumnName("h_id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastModifiedBy)
                    .HasColumnName("last_modified_by")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.LastModifiedTime)
                    .HasColumnName("last_modified_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.OutRate).HasColumnName("out_rate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
