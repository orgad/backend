using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_wms_ef.Models
{
    public partial class wmsinventoryContext : DbContext
    {
        public wmsinventoryContext()
        {
        }

        public wmsinventoryContext(DbContextOptions<wmsinventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TInvt> TInvts { get; set; }
        public virtual DbSet<TInvtD> TInvtDs { get; set; }
        public virtual DbSet<TInvtChangeLog> TInvtChangeLogs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                */
                optionsBuilder.UseMySql(DbConfig.InventoryDb, x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TInvtMapping());
            modelBuilder.ApplyConfiguration(new TInvtDMapping());
            modelBuilder.ApplyConfiguration(new TInvtChangeLogMapping());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
