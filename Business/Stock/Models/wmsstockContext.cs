using Microsoft.EntityFrameworkCore;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Stock.Models
{
    public partial class wmsstockContext : DbContext
    {
        public wmsstockContext()
        {
        }

        public wmsstockContext(DbContextOptions<wmsstockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TInvtMovePlan> TInvtMovePlans { get; set; }
        public virtual DbSet<TInvtMove> TInvtMoves { get; set; }


        public virtual DbSet<TInvtUp> TInvtUps { get; set; }
        public virtual DbSet<TInvtDown> TInvtDowns { get; set; }
        public virtual DbSet<TInvtSt> TSt { get; set; }
        public virtual DbSet<TStRep> TStRep { get; set; }
        public virtual DbSet<TStRepD> TStRepD { get; set; }
        public virtual DbSet<TInvtReplenishPlan> TInvtReplenishPlans { get; set; }
        public virtual DbSet<TInvtReplenishPlanD> TInvtReplenishPlanDs { get; set; }
        public virtual DbSet<TInvtReplenish> TInvtReplenishs { get; set; }
        public virtual DbSet<TInvtReplenishD> TInvtReplenishDs { get; set; }
        public virtual DbSet<TInvtCheck> TInvtChecks { get; set; }
        public virtual DbSet<TInvtCheckLimits> TInvtCheckLimits { get; set; }
        public virtual DbSet<TInvtCheckD> TInvtCheckDs { get; set; }
        public virtual DbSet<TInvtCheckLog> TInvtCheckLogs { get; set; }
        public virtual DbSet<TInvtAdj> TInvtAdjs { get; set; }
        public virtual DbSet<TInvtAdjD> TInvtAdjDs { get; set; }
        public virtual DbSet<TInvtFreeze> TInvtFreezes { get; set; }
        public virtual DbSet<TInvtFreezeD> TInvtFreezeDs { get; set; }
        public virtual DbSet<TInvtFreezeLimits> TInvtFreezeLimits { get; set; }
        public virtual DbSet<TInvtUnfreeze> TInvtUnfreezes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(DbConfig.StockDb, x => x.ServerVersion("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TInvtMovePlanMapping());
            modelBuilder.ApplyConfiguration(new TInvtMoveMapping());
            modelBuilder.ApplyConfiguration(new TInvtDownMapping());
            modelBuilder.ApplyConfiguration(new TInvtUpMapping());

            modelBuilder.ApplyConfiguration(new TInvtStMapping());
            modelBuilder.ApplyConfiguration(new TStRepMapping());
            modelBuilder.ApplyConfiguration(new TStRepDMapping());
            modelBuilder.ApplyConfiguration(new TInvtReplenishPlanMapping());
            modelBuilder.ApplyConfiguration(new TInvtReplenishPlanDMapping());
            modelBuilder.ApplyConfiguration(new TInvtReplenishMapping());
            modelBuilder.ApplyConfiguration(new TInvtReplenishDMapping());

            modelBuilder.ApplyConfiguration(new TInvtCheckMapping());
            modelBuilder.ApplyConfiguration(new TInvtCheckLimitsMapping());
            modelBuilder.ApplyConfiguration(new TInvtCheckDMapping());
            modelBuilder.ApplyConfiguration(new TInvtCheckLogMapping());
            modelBuilder.ApplyConfiguration(new TInvtAdjMapping());
            modelBuilder.ApplyConfiguration(new TInvtAdjDMapping());

            modelBuilder.ApplyConfiguration(new TInvtFreezeMapping());
            modelBuilder.ApplyConfiguration(new TInvtFreezeLimitsMapping());
            modelBuilder.ApplyConfiguration(new TInvtFreezeDMapping());
            modelBuilder.ApplyConfiguration(new TInvtUnfreezeMapping());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
