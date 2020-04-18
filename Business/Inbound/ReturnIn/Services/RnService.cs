using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.Inbound.ViewModels;
using dotnet_wms_ef.Services;
using Microsoft.AspNetCore.Http;

namespace dotnet_wms_ef.Inbound.Services
{
    public class RnService : BaseService
    {
        ExcelIOService ioService = new ExcelIOService();

        public string Root { get; set; }

        public RnService()
        {
            this.wms = new wmsinboundContext();
        }

        public List<TInRn> PageList(QueryRn queryRn)
        {
            return this.Query(queryRn).
            OrderByDescending(x => x.Id).Skip(queryRn.PageIndex).Take(queryRn.PageSize).ToList();
        }

        public int TotalCount(QueryRn queryRn)
        {
            return this.Query(queryRn).Count();
        }

        private IQueryable<TInRn> Query(QueryRn queryRn)
        {
            if (queryRn.PageSize == 0)
                queryRn.PageSize = 20;

            var query = wms.TInRns as IQueryable<TInRn>;
            return query;
        }

        public bool Create(VRnAddForm rnAddForm)
        {
            TInRn tRn = new TInRn();

            tRn.Code = "RN" + DateTime.Now.ToString(FormatString.DefaultFormat);
            tRn.BatchNo = rnAddForm.BatchNo ?? DateTime.Now.ToString("yyyyMMdd");
            tRn.WhId = rnAddForm.WhId;
            tRn.CustId = rnAddForm.CustId;
            tRn.BrandId = rnAddForm.BrandId;
            tRn.BizCode = rnAddForm.BizCode;
            tRn.TransCode = "Return";
            tRn.GoodsType = rnAddForm.GoodsType;
            tRn.TypeCode = "RN";
            tRn.Courier = rnAddForm.Courier;
            tRn.TrackingNo = rnAddForm.TrackingNo;
            tRn.RefCode = rnAddForm.RefCode;
            tRn.SrcCode = "Import";
            tRn.CreatedBy = DefaultUser.UserName;
            tRn.CreatedTime = DateTime.UtcNow;
            tRn.Status = "None";

            wms.TInRns.Add(tRn);
            return wms.SaveChanges() > 0;
        }

        public bool Import(IFormFile file, long id, string code)
        {
            ioService.basePath = this.Root;
            //保存文件
            DataTable dataTable = ioService.Import(file, "RN", code);

            var details = new List<TInRnD>();
            //写入到数据库
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                TInRnD d = new TInRnD();
                d.HId = id;
                d.Barcode = dataTable.Rows[i]["barcode"].ToString();
                d.Sku = dataTable.Rows[i]["sku"].ToString();
                d.Qty = Convert.ToInt32(dataTable.Rows[i]["qty"].ToString());
                d.CreatedBy = DefaultUser.UserName;
                d.CreatedTime = DateTime.UtcNow;
                details.Add(d);
            }
            return CreateDetail(id, details.ToArray());
        }

        public bool CreateDetail(long id, VRnDetailAddForm[] list)
        {
            var rnDetailList = new List<TInRnD>();

            foreach (var detail in list)
            {
                var t = new TInRnD
                {
                    Sku = detail.Sku,
                    Barcode = detail.Barcode,
                    Qty = detail.Qty
                };
                rnDetailList.Add(t);
            }

            return this.CreateDetail(id, rnDetailList.ToArray());
        }

        private bool CreateDetail(long id, TInRnD[] list)
        {
            var o = wms.TInRns.Where(x => x.Id == id).FirstOrDefault();
            if (o == null) return false;

            //o.PieceQty = details.Sum(x => x.Qty);
            //o.CartonQty = details.Where(x => !string.IsNullOrEmpty(x.Carton)).Distinct().Count();

            foreach (var d in list)
            {
                var n = new TInRnD
                {
                    HId = id,
                    Sku = d.Sku,
                    Barcode = d.Barcode,
                    Qty = d.Qty,
                    IsDeleted = false,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow,
                };
                wms.TInRnDs.Add(n);
            }

            return wms.SaveChanges() > 0;
        }

        public List<TInRnD> DetailListByExpressNo(string expressNo)
        {
            var ids = wms.TInRns.Where(x => x.TrackingNo == expressNo).Select(x => x.Id).ToList();
            var result = new List<TInRnD>();
            if (ids.Any())
            {
                var tmp = wms.TInRnDs.Where(x => ids.Contains(x.Id)).ToList();
                foreach (var item in tmp)
                {
                    for (int i = 0; i < item.Qty; i++)
                    {
                        result.Add(item);
                    }
                }
            }

            foreach (var item in result)
            {
                item.Qty = 1;
            }

            return result;
        }
    }
}