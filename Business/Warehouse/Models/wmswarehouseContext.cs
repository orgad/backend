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

        public virtual DbSet<TWhDutyracking> TWhDutyrackings { get; set; }

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

            modelBuilder.ApplyConfiguration(new TWhWarehouseMapping());
            modelBuilder.ApplyConfiguration(new TWhVirtualMapping());
            modelBuilder.ApplyConfiguration(new TWhZonetypeMapping());
            modelBuilder.ApplyConfiguration(new TWhZoneMapping());
            modelBuilder.ApplyConfiguration(new TWhDutyrackingMapping());
            modelBuilder.ApplyConfiguration(new TWhBinMapping());
            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
