using System;

namespace dotnet_wms_ef.ViewModels
{
    public class VAsnCheck
    {
        public long Id { get; set; }
        public long HId { get; set; }
        public string Code { get; set; }
        public string AsnCode{get;set;}
        public bool IsCiq { get; set; }
        public string Status { get; set; }
        public int AsnCartonQty{get;set;}
        public int AsnQty{get;set;}
        public int? CartonQty { get; set; }
        public int? Qty { get; set; }
        public int? DamageCartonQty { get; set; }
        public int? DamageQty { get; set; }
        public ulong? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}