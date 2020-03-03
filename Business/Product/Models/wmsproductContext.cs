using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_wms_ef.Models
{
    public partial class wmsproductContext : DbContext
    {
        public wmsproductContext()
        {
        }

        public wmsproductContext(DbContextOptions<wmsproductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TProdBarcode> TProdBarcode { get; set; }
        public virtual DbSet<TProdCatalog> TProdCatalog { get; set; }
        public virtual DbSet<TProdProduct> TProdProduct { get; set; }
        public virtual DbSet<TProdSku> TProdSkus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                */
                optionsBuilder.UseMySql("server=localhost;port=3306;database=db_product;user=root;password=8888", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TProdCatalogMapping());
            modelBuilder.ApplyConfiguration(new TProdProductMapping());
            modelBuilder.ApplyConfiguration(new TProdSkuMapping());
            modelBuilder.ApplyConfiguration(new TProdBarcodeMapping());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
