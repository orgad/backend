using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Views.ViewModels;
using Microsoft.AspNetCore.Http;

namespace dotnet_wms_ef.Services
{

    public class AsnService
    {
        wmsinboundContext wms = new wmsinboundContext();

        InboundService inboundService = new InboundService();

        ExcelIOService ioService = new ExcelIOService();

        public string Root{get;set;} //上传文件的路径

        public List<TInAsn> PageList(QueryAsn queryAsn)
        {
            return this.Query(queryAsn).
            OrderByDescending(x => x.Id).Skip(queryAsn.pageIndex).Take(queryAsn.pageSize).ToList();
        }

        private IQueryable<TInAsn> Query(QueryAsn queryAsn)
        {
            if (queryAsn.pageSize == 0)
                queryAsn.pageSize = 20;

            var query = wms.TInAsns as IQueryable<TInAsn>;

            if (queryAsn.whId > 0)
            {
                query = query.Where(x => x.WhId == queryAsn.whId);
            }

            if (queryAsn.custId > 0)
            {
                query = query.Where(x => x.CustId == queryAsn.custId);
            }

            if (queryAsn.brandId > 0)
            {
                query = query.Where(x => x.BrandId == queryAsn.brandId);
            }

            if (!string.IsNullOrEmpty(queryAsn.asnCode))
            {
                query = query.Where(x => x.Code == queryAsn.asnCode);
            }

            if (!string.IsNullOrEmpty(queryAsn.bizCode))
            {
                query = query.Where(x => x.BizCode == queryAsn.bizCode);
            }

            if (!string.IsNullOrEmpty(queryAsn.goodsType))
            {
                query = query.Where(x => x.GoodsType == queryAsn.goodsType);
            }

            if (!string.IsNullOrEmpty(queryAsn.status))
            {
                query = query.Where(x => x.Status == queryAsn.status);
            }

            if (!string.IsNullOrEmpty(queryAsn.checkStatus))
            {
                query = query.Where(x => x.CheckStatus == queryAsn.checkStatus);
            }

            if (queryAsn.isCiq != null)
            {
                query = query.Where(x => x.IsCiq == queryAsn.isCiq);
            }

            return query;
        }

        public int TotalCount(QueryAsn queryAsn)
        {
            return this.Query(queryAsn).Count();
        }

        public List<TInAsn> List()
        {
            return wms.TInAsns.ToList();
        }

        public VAsn Details(long id)
        {
            var o = wms.TInAsns.Where(x => x.Id == id).FirstOrDefault();

            var ds = wms.TInAsnDs.Where(x => x.HId == id).ToList();

            return new VAsn { Asn = o, AsnDs = ds.Any() ? ds.ToArray() : null };
        }

        public bool CreateFull(VAsn vAsn)
        {
            var o = new TInAsn
            {
                Code = DateTime.Now.ToString("yyyyMMddHHmmss"),
                RefCode = DateTime.Now.ToString("yyyyMMddHHmmss"),
                WhId = vAsn.Asn.WhId,
                CustId = vAsn.Asn.CustId,
                BrandId = vAsn.Asn.BrandId,
                BatchNo = vAsn.Asn.BatchNo ?? DateTime.Now.ToString("yyyyMMdd"),
                BizCode = vAsn.Asn.BizCode,
                GoodsType = vAsn.Asn.GoodsType,
                TypeCode = "Asn",
                TransCode = "Inbound",
                SrcCode = "Interface",
                IsCiq = false,
                Status = "None",
                CheckStatus = "None",
                IsDeleted = false,
                CreatedBy = "rickli",
                CreatedTime = DateTime.UtcNow

            };
            var ds = new List<TInAsnD>();


            foreach (var d in vAsn.AsnDs)
            {
                var n = new TInAsnD
                {
                    Sku = d.Sku,
                    Barcode = d.Barcode,
                    Qty = d.Qty,
                    IsDeleted = false,
                    CreatedBy = "rickli",
                    CreatedTime = DateTime.UtcNow,
                };
                ds.Add(n);
                o.DetailList.Add(n);
            }

            wms.TInAsns.Add(o);

            return wms.SaveChanges() > 0;
        }

        public bool CreateAsn(TInAsn tAsn)
        {
            var o = new TInAsn
            {
                Code = Enum.GetName(typeof(EnumOrderType), EnumOrderType.ASN) + DateTime.Now.ToString("yyyyMMddHHmmss"),
                RefCode = DateTime.Now.ToString("yyyyMMddHHmmss"),
                WhId = tAsn.WhId,
                CustId = tAsn.CustId,
                BrandId = tAsn.BrandId,
                BatchNo = tAsn.BatchNo ?? DateTime.Now.ToString("yyyyMMdd"),
                BizCode = tAsn.BizCode,
                GoodsType = tAsn.GoodsType,
                TypeCode = Enum.GetName(typeof(EnumOrderType), EnumOrderType.ASN),
                TransCode = "Inbound",
                SrcCode = "Import",
                IsCiq = false,
                Status = "None",
                CheckStatus = "None",
                IsDeleted = false,
                CreatedBy = "rickli",
                CreatedTime = DateTime.UtcNow
            };

            wms.TInAsns.Add(o);
            try
            {
                return wms.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }

        public bool Upload(IFormFile file, long id, string code)
        {
            ioService.basePath = this.Root;
            //保存文件
            DataTable dataTable = ioService.Import(file, code);

            var details = new List<TInAsnD>();
            //写入到数据库
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                TInAsnD d = new TInAsnD();
                d.HId = id;
                d.Barcode = dataTable.Rows[i]["barcode"].ToString();
                d.Sku = dataTable.Rows[i]["sku"].ToString();
                d.Qty = Convert.ToInt32(dataTable.Rows[i]["qty"].ToString());
                d.CreatedBy = "rickli";
                d.CreatedTime = DateTime.UtcNow;
                details.Add(d);
            }
            return CreateAsnDetail(id, details.ToArray());
        }

        public bool CreateAsnDetail(long id, TInAsnD[] details)
        {
            var o = wms.TInAsns.Where(x => x.Id == id).FirstOrDefault();
            if (o == null) return false;
            o.PieceQty = details.Sum(x => x.Qty);
            foreach (var d in details)
            {
                var n = new TInAsnD
                {
                    HId = id,
                    Sku = d.Sku,
                    Barcode = d.Barcode,
                    Qty = d.Qty,
                    IsDeleted = false,
                    CreatedBy = "rickli",
                    CreatedTime = DateTime.UtcNow,
                };
                wms.TInAsnDs.Add(n);
            }

            return wms.SaveChanges() > 0;
        }

        public string DownLoad(long id, string code)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sku");
            dt.Columns.Add("barcode");
            dt.Columns.Add("qty");
            var items = wms.TInAsnDs.Where(x => x.HId == id).ToList();
            foreach (var item in items)
            {
                var dr = dt.NewRow();
                dr["sku"] = item.Sku;
                dr["barcode"] = item.Barcode;
                dr["qty"] = item.Qty;
                dt.Rows.Add(dr);
            }
            return ioService.Export(code, dt);
        }

        //
        // 调用验货服务生成验货单
        //
        public bool Affirm(long[] ids)
        {
            var asns = wms.TInAsns.Where(x => ids.Contains(x.Id)).ToList();
            int i = 0;
            foreach (var asn in asns)
            {
                if (asn.Status == Enum.GetName(typeof(EnumStatus),EnumStatus.None))
                {
                    asn.Status = Enum.GetName(typeof(EnumStatus),EnumStatus.Audit);
                    asn.CheckStatus = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Init);
                    var o = new AsnCheckService().Create(asn);
                    wms.Add(o);
                    i++;
                }
            }
            wms.SaveChanges();
            return i > 0;
        }

        public List<Tuple<long,bool>> Check(long[] ids)
        {
            var list = new List<Tuple<long,bool>>();
            //生成入库单
            var asns = wms.TInAsns.Where(x => ids.Contains(x.Id)).ToList();
            foreach (var asn in asns)
            {
                var r = inboundService.Create(asn);
                wms.TInInbounds.Add(r);
                //修改到货通知单的单据状态
                asn.CheckStatus = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Finished);
                
                var result = wms.SaveChanges()>0;
                list.Add(new Tuple<long, bool>(asn.Id,result));
            }
            return list;
        }
    }
}