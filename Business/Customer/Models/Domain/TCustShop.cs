using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TCustShop
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CustId { get; set; }
        public string NameEn { get; set; }
        public string NameCn { get; set; }
        public string Contact { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual TCustCustomer Cust { get; set; }
    }
}
