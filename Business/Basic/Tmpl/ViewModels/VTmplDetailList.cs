using System.Collections.Generic;
using dotnet_wms_ef.Basic.Models;

namespace dotnet_wms_ef.Basic.ViewModels
{
    public class VTmplDetailList
    {
        public long Id { get; set; }
        public int WhId { get; set; }
        public int CustId { get; set; }
        public int BrandId { get; set; }
        public string TypeCode { get; set; }
        public string SubTypeCode { get; set; }
        public int TmplId { get; set; }
        public string TmplTitle { get; set; }
        public string TmplData { get; set; }
        public bool IsChild { get; set; }
        public int Seq { get; set; }
    }
}