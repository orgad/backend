using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Models
{
    public partial class TOutHandover
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int WhId { get; set; }
        public int CustId { get; set; }
        public string Store { get; set; }
        public string Driver { get; set; }
        public string PlateNo { get; set; }
        public string Comment { get; set; }
        public bool IsConfirm { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
