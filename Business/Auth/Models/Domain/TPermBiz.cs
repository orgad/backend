using System;

namespace dotnet_wms_ef.Auth.Models
{
    public partial class TPermBiz
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int WhId { get; set; }
        public string WhCode { get; set; }
        public int CustId { get; set; }
        public string CustCode { get; set; }
        public int BrandId { get; set; }
        public string BrandCode { get; set; }
        public string BizCode { get; set; }
        public string Comment { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

    }
}