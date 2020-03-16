using System;
using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_wms_ef.Business.Models
{
    public partial class wmsoutboundContext : DbContext
    {
        public wmsoutboundContext()
        {
        }

        public wmsoutboundContext(DbContextOptions<wmsoutboundContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TOut> TOuts { get; set; }
        public virtual DbSet<TOutAddress> TOutAddress { get; set; }
        public virtual DbSet<TOutAlot> TOutAlot { get; set; }
        public virtual DbSet<TOutAlotD> TOutAlotD { get; set; }
        public virtual DbSet<TOutCheck> TOutCheck { get; set; }
        public virtual DbSet<TOutCheckD> TOutCheckD { get; set; }
        public virtual DbSet<TOutD> TOutDs { get; set; }
        public virtual DbSet<TOutDn> TOutDns { get; set; }
        public virtual DbSet<TOutDnD> TOutDnDs { get; set; }
        public virtual DbSet<TOutExpress> TOutExpress { get; set; }
        public virtual DbSet<TOutHandover> TOutHandover { get; set; }
        public virtual DbSet<TOutHandoverD> TOutHandoverD { get; set; }
        public virtual DbSet<TOutPick> TOutPick { get; set; }
        public virtual DbSet<TOutPickD> TOutPickD { get; set; }
        public virtual DbSet<TOutWave> TOutWave { get; set; }
        public virtual DbSet<TSt> TSt { get; set; }
        public virtual DbSet<TStAllot> TStAllot { get; set; }
        public virtual DbSet<TStD> TStD { get; set; }
        public virtual DbSet<TStDelivery> TStDelivery { get; set; }
        public virtual DbSet<TStOpt> TStOpt { get; set; }
        public virtual DbSet<TStPick> TStPick { get; set; }
        public virtual DbSet<TStWave> TStWave { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(DbConfig.OutboundDb, x => x.ServerVersion("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TOutDnMapping());
            modelBuilder.ApplyConfiguration(new TOutDnDMapping());

            modelBuilder.ApplyConfiguration(new TOutMapping());
            modelBuilder.ApplyConfiguration(new TOutDMapping());
            modelBuilder.ApplyConfiguration(new TOutAddressMapping());

            modelBuilder.ApplyConfiguration(new TOutAlotMapping());
            modelBuilder.ApplyConfiguration(new TOutAlotDMapping());

            modelBuilder.ApplyConfiguration(new TOutWaveMapping());
            modelBuilder.ApplyConfiguration(new TOutPickMapping());
            modelBuilder.ApplyConfiguration(new TOutPickDMapping());

            modelBuilder.ApplyConfiguration(new TOutExpressMapping());

            modelBuilder.ApplyConfiguration(new TOutCheckMapping());
            modelBuilder.ApplyConfiguration(new TOutCheckDMapping());

            modelBuilder.ApplyConfiguration(new TOutHandoverMapping());
            modelBuilder.ApplyConfiguration(new TOutHandoverDMapping());

            modelBuilder.ApplyConfiguration(new TOutStMapping());
            modelBuilder.ApplyConfiguration(new TOutStOptMapping());
            modelBuilder.ApplyConfiguration(new TOutStDMapping());
            modelBuilder.ApplyConfiguration(new TOutStDeliveryMapping());
            modelBuilder.ApplyConfiguration(new TOutStAlotMapping());
            modelBuilder.ApplyConfiguration(new TOutStPickMapping());
            modelBuilder.ApplyConfiguration(new TOutStWaveMapping());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
