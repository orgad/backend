using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TCustBrand
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? CustId { get; set; }
        public string AddressEn { get; set; }
        public string AddressLc { get; set; }
        public string NameEn { get; set; }
        public string NameLc { get; set; }
        public string Contact { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual TCustCustomer Cust { get; set; }
    }
}
