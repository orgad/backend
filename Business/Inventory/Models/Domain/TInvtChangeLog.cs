using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TInvtChangeLog
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string OrderType { get; set; }
        public long InvtDId { get; set; }
        public int WhId { get; set; }
        public int CustId { get; set; }
        public long SkuId { get; set; }
        public string Carton { get; set; }
        public string Barcode { get; set; }
        public int ZoneId { get; set; }
        public int BinId { get; set; }
        public int Qty { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual TInvtD TInvtD { get; set; }
    }
}
