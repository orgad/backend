using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Auth.Models
{
    public partial class TPermRole
    {
        public int Id { get; set; }
        public string CodeNo { get; set; }
        public string NameCn { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
