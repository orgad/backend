using dotnet_wms_ef.Basic.Models;
using dotnet_wms_ef.Basic.ViewModels;
using System.Linq;

namespace dotnet_wms_ef.Basic.Services
{
    public class PrintTmplService
    {
        wmsbasicContext wmsbasic = new wmsbasicContext();
        public string[] TmplData(QueryTmpl query)
        {
            var st = wmsbasic.TTmplSts
                             .Where(x => x.WhId == query.WhId && x.CustId == query.CustId && x.BrandId == query.BrandId)
                             .Select(x => x.Id).FirstOrDefault();

            var tmpl = wmsbasic.TTmplPrints
                               .Where(x => x.StId == st && x.TypeCode == query.TypeCode &&
                                      x.SubTypeCode == query.SubTypeCode)
                               .FirstOrDefault();
                               
            var datas = wmsbasic.TTmplPrintDs
                                .Where(x => x.TmplId == tmpl.Id)
                                .OrderBy(x => x.Seq)
                                .Select(x => x.TmplData).ToArray();

            return datas;
        }
    }
}