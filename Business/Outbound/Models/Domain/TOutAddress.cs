using System;
using System.Collections.Generic;

namespace dotnet_wms_ef.Business.Models
{
    public partial class TOutAddress
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public int TypeCode { get; set; }
        public string NameCn { get; set; }
        public string NameEn { get; set; }
        public string Contact { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string ProvinceCode { get; set; }
        public string Province { get; set; }
        public string CityCode { get; set; }
        public string City { get; set; }
        public string DistrictCode { get; set; }
        public string District { get; set; }
        public string TownCode { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public ulong IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
