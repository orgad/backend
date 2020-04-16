using System;
using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_wms_ef.Inbound.Models
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


        public virtual DbSet<TSt> TSts { get; set; }
        public virtual DbSet<TStD> TStDs { get; set; }
        public virtual DbSet<TStOpt> TStOpts { get; set; }
        public virtual DbSet<TStRcv> TStRcvs { get; set; }
        public virtual DbSet<TStPutaway> TStPutaways { get; set; }
        public virtual DbSet<TStPutawayD> TStPutawayDs { get; set; }

        public virtual DbSet<TInAsn> TInAsns { get; set; }
        public virtual DbSet<TInAsnCiq> TInAsnCiq { get; set; }
        public virtual DbSet<TInAsnD> TInAsnDs { get; set; }
        public virtual DbSet<TInCheck> TInChecks { get; set; }
        public virtual DbSet<TInCheckD> TInCheckDs { get; set; }
        public virtual DbSet<TInInbound> TInInbounds { get; set; }
        public virtual DbSet<TInInboundD> TInInboundDs { get; set; }
        public virtual DbSet<TInInboundRcv> TInInboundRcvs { get; set; }
        public virtual DbSet<TInOptlog> TInOptlogs { get; set; }
        public virtual DbSet<TInQc> TInQcs { get; set; }
        public virtual DbSet<TInQcD> TInQcDs { get; set; }
        public virtual DbSet<TInPutawayAdvice> TInPutawayAdvice { get; set; }
        public virtual DbSet<TInPutaway> TInPutaways { get; set; }
        public virtual DbSet<TInPutawayD> TInPutawayDs { get; set; }
        public virtual DbSet<TInValue> TInValue { get; set; }
        public virtual DbSet<TInLog> TInLogs { get; set; }
        public virtual DbSet<TInRn> TInRns { get; set; }
        public virtual DbSet<TInRnD> TInRnDs { get; set; }

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

            modelBuilder.ApplyConfiguration(new TInStMapping());
            modelBuilder.ApplyConfiguration(new TInStOptMapping());
            modelBuilder.ApplyConfiguration(new TInStDMapping());
            modelBuilder.ApplyConfiguration(new TInStRcvMapping());
            modelBuilder.ApplyConfiguration(new TInStPutawayMapping());
            modelBuilder.ApplyConfiguration(new TInStPutawayDMapping());

            modelBuilder.ApplyConfiguration(new TInAsnMapping());
            modelBuilder.ApplyConfiguration(new TInAsnCiqMapping());
            modelBuilder.ApplyConfiguration(new TInAsnDMapping());
            modelBuilder.ApplyConfiguration(new TInCheckMapping());
            modelBuilder.ApplyConfiguration(new TInCheckDMapping());
            modelBuilder.ApplyConfiguration(new TInInboundMapping());
            modelBuilder.ApplyConfiguration(new TInInboundDMapping());
            modelBuilder.ApplyConfiguration(new TInInboundRcvMapping());
            modelBuilder.ApplyConfiguration(new TInOptLogMapping());
            modelBuilder.ApplyConfiguration(new TInQcMapping());
            modelBuilder.ApplyConfiguration(new TInQcDMapping());
            modelBuilder.ApplyConfiguration(new TInPutAwayMapping());
            modelBuilder.ApplyConfiguration(new TInPutAwayDMapping());

            modelBuilder.ApplyConfiguration(new TInLogMapping());
            modelBuilder.ApplyConfiguration(new TInValueMapping());

            modelBuilder.ApplyConfiguration(new TInRtnMapping());
            modelBuilder.ApplyConfiguration(new TInRtnDMapping());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
