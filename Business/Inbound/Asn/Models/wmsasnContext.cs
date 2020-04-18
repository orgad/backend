
using Microsoft.EntityFrameworkCore;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class wmsinboundContext : DbContext
    {
        public virtual DbSet<TInAsn> TInAsns { get; set; }
        public virtual DbSet<TInAsnCiq> TInAsnCiq { get; set; }
        public virtual DbSet<TInAsnD> TInAsnDs { get; set; }
        public virtual DbSet<TInCheck> TInChecks { get; set; }
        public virtual DbSet<TInCheckD> TInCheckDs { get; set; }
    }
}