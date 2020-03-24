using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_wms_ef.Models
{
    public partial class wmssupplierContext : DbContext
    {
        public wmssupplierContext()
        {
        }

        public wmssupplierContext(DbContextOptions<wmssupplierContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TSupCourier> TSupCouriers { get; set; }
        public virtual DbSet<TSupSupplier> TSupSuppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(DbConfig.SupplierDb, x => x.ServerVersion("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TSupCourierMapping());
            modelBuilder.ApplyConfiguration(new TSupSupplierMapping());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
