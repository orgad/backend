using System.Collections.Generic;
using dotnet_wms_ef.Basic.Models;

namespace dotnet_wms_ef.Basic.ViewModels
{
    public class VTmplDetails
    {
        public VTmpl Tmpl { get; set; }
        public ICollection<TTmplPrintD> DetailList { get; set; }
    }
}