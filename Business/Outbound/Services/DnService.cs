using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;
using Microsoft.AspNetCore.Http;

namespace dotnet_wms_ef.Services
{
    public class DnService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        ExcelIOService ioService = new ExcelIOService();

        OutboundService outboundService = new OutboundService();

        public string Root { get; set; } //上传文件的路径

        public Tuple<bool, string> Create(TOutDn dn)
        {
            dn.Code = "DN" + DateTime.Now.ToString(FormatString.DefaultFormat);
            if (string.IsNullOrEmpty(dn.BatchNo))
            {
                dn.BatchNo = DateTime.Now.ToString("yyyyMMdd");
            }
            dn.TypeCode = "DN";
            dn.TransCode = "Outbound";
            dn.SrcCode = "Import";
            dn.Status = "None";
            dn.IsDeleted = false;

            dn.CreatedBy = DefaultUser.UserName;
            dn.CreatedTime = DateTime.UtcNow;

            wmsoutbound.Add(dn);

            var result = wmsoutbound.SaveChanges() > 0;
            return new Tuple<bool, string>(result, "");
        }

        public Tuple<bool, string> UpdateDn(TOutDn vOutDn)
        {
            //首先去查询一把
            var dn = wmsoutbound.TOutDns.Where(x => x.Id == vOutDn.Id).FirstOrDefault();
            dn.WhId = vOutDn.WhId;
            dn.CustId = vOutDn.CustId;
            dn.BrandId = vOutDn.BrandId;
            dn.RefNo = vOutDn.RefNo;
            dn.Payment = vOutDn.Payment;
            dn.GoodsType = vOutDn.GoodsType;
            dn.BizCode = vOutDn.BizCode;

            var result = wmsoutbound.SaveChanges() > 0;
            return new Tuple<bool, string>(result, "");
        }

        public bool Upload(IFormFile file, long id, string code)
        {
            ioService.basePath = this.Root;
            //保存文件
            DataTable dataTable = ioService.Import(file, "DN", code);

            var details = new List<TOutDnD>();
            //写入到数据库
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                TOutDnD d = new TOutDnD();
                d.HId = id;
                d.Barcode = dataTable.Rows[i]["barcode"].ToString();
                d.Sku = dataTable.Rows[i]["sku"].ToString();
                d.Qty = Convert.ToInt32(dataTable.Rows[i]["qty"].ToString());
                d.CreatedBy = "rickli";
                d.CreatedTime = DateTime.UtcNow;
                details.Add(d);
            }
            var r = CreateDnDetail(id, details.ToArray());
            return r;
        }

        public bool CreateDnDetail(long id, TOutDnD[] details)
        {
            var o = wmsoutbound.TOutDns.Where(x => x.Id == id).FirstOrDefault();
            if (o == null) return false;
            o.Qty = details.Sum(x => x.Qty);
            foreach (var d in details)
            {
                var n = new TOutDnD
                {
                    HId = id,
                    Sku = d.Sku,
                    Barcode = d.Barcode,
                    Qty = d.Qty,
                    //IsDeleted = false,
                    CreatedBy = "rickli",
                    CreatedTime = DateTime.UtcNow,
                };
                wmsoutbound.TOutDnDs.Add(n);
            }

            return wmsoutbound.SaveChanges() > 0;
        }

        public List<TOutDn> PageList(QueryDn queryDn)
        {
            return this.Query(queryDn).OrderByDescending(x => x.Id).ToList();
        }

        public int TotalCount(QueryDn queryDn)
        {
            return this.Query(queryDn).Count();
        }

        private IQueryable<TOutDn> Query(QueryDn queryDn)
        {
            var query = wmsoutbound.TOutDns;
            return query;
        }

        public VDnDetails Details(long dnId)
        {
            var dn = wmsoutbound.TOutDns.Where(x => x.Id == dnId).FirstOrDefault();
            var detailList = wmsoutbound.TOutDnDs.Where(x => x.HId == dnId).ToArray();

            return new VDnDetails { Dn = dn, DetailList = detailList };
        }

        public List<Tuple<bool, long, string>> Audit(long[] ids)
        {
            var list = new List<Tuple<bool, long, string>>();
            var dns = wmsoutbound.TOutDns.Where(x => x.Status == "None" && ids.Contains(x.Id)).ToList();
            //排除已经审核过的
            foreach (var id in ids)
            {
                if (!dns.Any(x => x.Id == id))
                {
                    list.Add(new Tuple<bool, long, string>(false, id, ""));
                }
            }

            //处理剩余的
            foreach (var dn in dns)
            {
                outboundService.CreateOutFromDn(dn);
                dn.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Audit);
                var r = wmsoutbound.SaveChanges() > 0;
                list.Add(new Tuple<bool, long, string>(r, dn.Id, ""));
            }
            return list;
        }
    }
}