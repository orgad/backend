﻿using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TCustCustomer
    {
        public TCustCustomer()
        {
            TCustBrand = new HashSet<TCustBrand>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameCn { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }

        public virtual ICollection<TCustBrand> TCustBrand { get; set; }

        public virtual ICollection<TCustShop> TCustShop { get; set; }
    }
}
