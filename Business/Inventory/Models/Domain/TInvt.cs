using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInvt
    {
        public TInvt()
        {
            DetailList = new List<TInvtD>();
        }
        public long Id { get; set; }
        public int WhId { get; set; }
        public long SkuId { get; set; }
        public string Sku { get; set; }
        public string Barcode { get; set; }
        public int Qty { get; set; }
        public decimal? Weight { get; set; }
        public int AlotQty { get; set; }
        public int LockedQty { get; set; }
        public string Other01 { get; set; }
        public string Other02 { get; set; }
        public string Other03 { get; set; }
        public string Other04 { get; set; }
        public string Other05 { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public ICollection<TInvtD> DetailList { get; set; }
    }
}
