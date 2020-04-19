using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Inbound.Aop;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.Inbound.ViewModels;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Inbound.Services
{
    public class PreQcService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();
        InboundService inboundService = new InboundService();

        //分页查询
        public List<TInPreQc> PageList()
        {
            return this.Query().OrderByDescending(x => x.Id).ToList();
        }

        private IQueryable<TInPreQc> Query()
        {
            var q = wmsinbound.TInPreQcs as IQueryable<TInPreQc>;
            return q;
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        public VPreQcDetails Details(long id)
        {
            var o = wmsinbound.TInPreQcs.Where(x => x.Id == id).FirstOrDefault();

            var ds = wmsinbound.TInPreQcDs.Where(x => x.HId == id).ToList();

            return new VPreQcDetails { PreQc = o, DetailList = ds.Any() ? ds.ToArray() : null };
        }

        public bool CreateDetailList(long id, VPreQcDetail[] list)
        {
            var ds = new List<TInPreQcD>();
            foreach (var detail in list)
            {
                TInPreQcD d = new TInPreQcD
                {
                    NoticeId = detail.NoticeId,
                    NoticeCode = detail.NoticeCode,
                    NoticeDId = detail.NoticeDId,
                    Carton = detail.Carton,
                    SkuId = detail.SkuId,
                    Sku = detail.Sku,
                    Barcode = detail.Barcode,
                    QcCode = detail.QcCode
                };

                d.HId = id;
                d.CreatedBy = DefaultUser.UserName;
                d.CreatedTime = DateTime.UtcNow;

                ds.Add(d);

            }

            wmsinbound.TInPreQcDs.AddRange(ds);

            return wmsinbound.SaveChanges() > 0;
        }

        public bool Confirm(long[] ids)
        {
            var qcs = wmsinbound.TInPreQcs.Where(x => ids.Contains(x.Id)).ToList();
            var batchCode = inboundService.CreateByPreQc("ReturnIn", qcs.ToArray());
             
            foreach(var qc in qcs)
            {
                qc.InBatchCode = batchCode;
                qc.Status = "Finished";
            } 

            return wmsinbound.SaveChanges() > 0;
        }
    }
}