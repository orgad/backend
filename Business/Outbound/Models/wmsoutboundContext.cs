using System;
using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_wms_ef.Models
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
        public virtual DbSet<TOutAlot> TOutAlots { get; set; }
        public virtual DbSet<TOutAlotD> TOutAlotDs { get; set; }
        public virtual DbSet<TOutCheck> TOutChecks { get; set; }
        public virtual DbSet<TOutCheckD> TOutCheckDs { get; set; }
        public virtual DbSet<TOutD> TOutDs { get; set; }
        public virtual DbSet<TOutDn> TOutDns { get; set; }
        public virtual DbSet<TOutDnD> TOutDnDs { get; set; }
        public virtual DbSet<TOutExpress> TOutExpresses { get; set; }
        public virtual DbSet<TOutHandover> TOutHandovers { get; set; }
        public virtual DbSet<TOutHandoverD> TOutHandoverDs { get; set; }
        public virtual DbSet<TOutPick> TOutPicks { get; set; }
        public virtual DbSet<TOutPickD> TOutPickDs { get; set; }
        public virtual DbSet<TOutWave> TOutWaves { get; set; }
        public virtual DbSet<TOutSt> TSts { get; set; }
        public virtual DbSet<TStAllot> TStAllots { get; set; }
        public virtual DbSet<TOutStD> TStDs { get; set; }
        public virtual DbSet<TStDelivery> TStDelivery { get; set; }
        public virtual DbSet<TOutStOpt> TStOpts { get; set; }
        public virtual DbSet<TStPick> TStPicks { get; set; }
        public virtual DbSet<TStWave> TStWaves { get; set; }

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
