using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInvtD
    {
        public TInvt TInvt { get; set; }
        public long Id { get; set; }
        public long HId { get; set; }
        public int WhId { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public string Carton { get; set; }
        public string Barcode { get; set; }
        public int ZoneId { get; set; }
        public string ZoneCode { get; set; }
        public int BinId { get; set; }
        public string BinCode { get; set; }
        public int Qty { get; set; }
        public decimal? Weight { get; set; }
        public int AlotQty { get; set; }
        public int LockedQty { get; set; }
        public string LotKey { get; set; }
        public string Other01 { get; set; }
        public string Other02 { get; set; }
        public string Other03 { get; set; }
        public string Other04 { get; set; }
        public string Other05 { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual TInvtChangeLog TInvtChangeLog { get; set; }
    }
}
