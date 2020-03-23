using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_wms_ef.Models
{
    public partial class wmscustomerContext : DbContext
    {
        public wmscustomerContext()
        {
        }

        public wmscustomerContext(DbContextOptions<wmscustomerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TCustBrand> TCustBrands { get; set; }
        public virtual DbSet<TCustCustomer> TCustCustomers { get; set; }
        public virtual DbSet<TCustShop> TCustShops{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                */
                optionsBuilder.UseMySql(DbConfig.CustomerDb, x => x.ServerVersion("8.0.16-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TCustCustomerMapping());
            modelBuilder.ApplyConfiguration(new TCustBrandMapping());
            modelBuilder.ApplyConfiguration(new TCustShopMapping());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
