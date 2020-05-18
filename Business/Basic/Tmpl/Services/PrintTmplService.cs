using dotnet_wms_ef.Basic.Models;
using dotnet_wms_ef.Basic.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_wms_ef.Basic.Services
{
    public class PrintTmplService
    {
        wmsbasicContext wmsbasic = new wmsbasicContext();

        public List<VTmpl> PageList()
        {
            return this.Query().ToList();
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        private IQueryable<VTmpl> Query()
        {
            var o = from tmpl in wmsbasic.TTmplPrints
                    join st in wmsbasic.TTmplSts on tmpl.StId equals st.Id
                    select new VTmpl
                    {
                        Id = tmpl.Id,
                        WhId = st.WhId,
                        CustId = st.CustId,
                        BrandId = st.BrandId,
                        TypeCode = tmpl.TypeCode,
                        SubTypeCode = tmpl.TypeCode
                    };
            return o as IQueryable<VTmpl>;
        }

        public VTmplDetails Details(long id)
        {
            var o = this.Query().Where(x => x.Id == id).FirstOrDefault();
            var d = wmsbasic.TTmplPrintDs.Where(x => x.TmplId == id).ToList();

            return new VTmplDetails { Tmpl = o, DetailList = d };
        }

        public string TmplDataById(long id)
        {
            var tmplData = wmsbasic.TTmplPrintDs.Where(x => x.Id == id).Select(x => x.TmplData).FirstOrDefault();
            return tmplData;
        }

        public bool UpdateTmplData(long id, string encryData)
        {
            var tmplData = wmsbasic.TTmplPrintDs.Where(x => x.Id == id).FirstOrDefault();
            if (tmplData != null)
            {
                tmplData.TmplData = encryData;
                return wmsbasic.SaveChanges() > 0;
            }
            else return false;
        }

        public string[] TmplData(QueryTmpl query)
        {
            var datas = new string[] { };
            var st = wmsbasic.TTmplSts
                             .Where(x => x.WhId == query.WhId && x.CustId == query.CustId && x.BrandId == query.BrandId)
                             .Select(x => x.Id).FirstOrDefault();
            if (st > 0)
            {
                var tmpl = wmsbasic.TTmplPrints
                                   .Where(x => x.StId == st && x.TypeCode == query.TypeCode &&
                                          x.SubTypeCode == query.SubTypeCode)
                                   .FirstOrDefault();
                if (tmpl != null)
                {
                    datas = wmsbasic.TTmplPrintDs
                                        .Where(x => x.TmplId == tmpl.Id)
                                        .OrderBy(x => x.Seq)
                                        .Select(x => x.TmplData).ToArray();
                }
            }
            return datas;
        }
    }
}