﻿using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TWhZonetype
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameCn { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
