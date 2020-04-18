using System;
using dotnet_wms_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_wms_ef.Inbound.Models
{
    public partial class wmsinboundContext : DbContext
    {
        public virtual DbSet<TInRn> TInRns { get; set; }
        public virtual DbSet<TInRnD> TInRnDs { get; set; }
        public virtual DbSet<TInRnPkg> TInRnPkgs { get; set; }
        public virtual DbSet<TInPreQc> TInPreQcs { get; set; }
        public virtual DbSet<TInPreQcD> TInPreQcDs { get; set; }
    }
}