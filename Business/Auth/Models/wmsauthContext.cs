using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_wms_ef.Auth.Models
{
    public partial class wmsauthContext : DbContext
    {
        public wmsauthContext()
        {
        }

        public wmsauthContext(DbContextOptions<wmsauthContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TPermNav> TPermNavs { get; set; }
        public virtual DbSet<TPermNavAction> TPermNavActions { get; set; }
        public virtual DbSet<TPermRole> TPermRoles { get; set; }
        public virtual DbSet<TPermRoleNav> TPermRoleNavs { get; set; }
        public virtual DbSet<TPermBiz> TPermBizs { get; set; }
        public virtual DbSet<TPermUser> TPermUsers { get; set; }
        public virtual DbSet<TPermUserRole> TPermUserRoles { get; set; }
        public virtual DbSet<TPermUserBiz> TPermUserBizs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(DbConfig.AuthDb, x => x.ServerVersion("8.0.19-mysql"));
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TPermNavMapping());
            modelBuilder.ApplyConfiguration(new TPermNavActionMapping());
            modelBuilder.ApplyConfiguration(new TPermRoleMapping());
            modelBuilder.ApplyConfiguration(new TPermBizMapping());
            modelBuilder.ApplyConfiguration(new TPermRoleNavMapping());
            modelBuilder.ApplyConfiguration(new TPermUserMapping());
            modelBuilder.ApplyConfiguration(new TPermUserRoleMapping());
            modelBuilder.ApplyConfiguration(new TPermUserBizMapping());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
