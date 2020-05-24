using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_wms_ef.Product.Models
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

        public virtual DbSet<TProdBarcode> TProdBarcodes { get; set; }
        public virtual DbSet<TProdCatalog> TProdCatalogs { get; set; }
        public virtual DbSet<TProdProduct> TProdProducts { get; set; }
        public virtual DbSet<TProdSku> TProdSkus { get; set; }
        public virtual DbSet<TProdMat> TProdMats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                /*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                */
                optionsBuilder.UseMySql(DbConfig.ProductDb, x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TProdCatalogMapping());
            modelBuilder.ApplyConfiguration(new TProdProductMapping());
            modelBuilder.ApplyConfiguration(new TProdSkuMapping());
            modelBuilder.ApplyConfiguration(new TProdBarcodeMapping());
            modelBuilder.ApplyConfiguration(new TProdMatMapping());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
