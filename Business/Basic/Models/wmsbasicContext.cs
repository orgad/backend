using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_wms_ef.Basic.Models
{
    public partial class wmsbasicContext : DbContext
    {
        public wmsbasicContext()
        {
        }

        public wmsbasicContext(DbContextOptions<wmsbasicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TTmplImport> TTmplImports { get; set; }
        public virtual DbSet<TTmplImportD> TTmplImportDs { get; set; }
        public virtual DbSet<TTmplPrint> TTmplPrints { get; set; }
        public virtual DbSet<TTmplPrintConfig> TTmplPrintConfigs { get; set; }
        public virtual DbSet<TTmplPrintD> TTmplPrintDs { get; set; }
        public virtual DbSet<TTmplSt> TTmplSts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(DbConfig.BasicDb, x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TTmplStMapping());
            
            modelBuilder.ApplyConfiguration(new TTmplPrintMapping());
            modelBuilder.ApplyConfiguration(new TTmplPrintDMapping());
            modelBuilder.ApplyConfiguration(new TTmplPrintConfigMapping());

            modelBuilder.ApplyConfiguration(new TTmplImportMapping());
            modelBuilder.ApplyConfiguration(new TTmplImportDMapping());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
