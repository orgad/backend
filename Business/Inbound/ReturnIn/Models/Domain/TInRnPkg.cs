using System;

namespace dotnet_wms_ef.Inbound.Models
{
    public class TInRnPkg
    {
        public long Id{get;set;}
        public string Courier{get;set;}
        public string TrackingNo{get;set;}
        public bool IsDeleted { get; set; } //是否删除
        public string CreatedBy { get; set; } //创建人
        public DateTime CreatedTime { get; set; } //创建时间
        public DateTime? LastModifiedTime { get; set; } //修改时间
        public string LastModifiedBy { get; set; } //修改人       
    }
}