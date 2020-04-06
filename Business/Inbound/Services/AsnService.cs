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

    public class AsnService : BaseService
    {
        ExcelIOService ioService = new ExcelIOService();

        AsnCheckService asnCheckService = new AsnCheckService();

        public string Root { get; set; } //上传文件的路径

        public AsnService()
        {
            this.wms = new wmsinboundContext();
        }

        public List<TInAsn> PageList(QueryAsn queryAsn)
        {
            return this.Query(queryAsn).
            OrderByDescending(x => x.Id).Skip(queryAsn.PageIndex).Take(queryAsn.PageSize).ToList();
        }

        private IQueryable<TInAsn> Query(QueryAsn queryAsn)
        {
            if (queryAsn.PageSize == 0)
                queryAsn.PageSize = 20;

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

        public VAsnDetails Details(long id)
        {
            var o = wms.TInAsns.Where(x => x.Id == id).FirstOrDefault();

            var ds = wms.TInAsnDs.Where(x => x.HId == id).ToList();

            return new VAsnDetails { Asn = o, AsnDs = ds.Any() ? ds.ToArray() : null };
        }

        public bool CreateFull(VAsnDetails vAsn)
        {
            var o = new TInAsn
            {
                Code = DateTime.Now.ToString(FormatString.DefaultFormat),
                RefCode = DateTime.Now.ToString(FormatString.DefaultFormat),
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

        public Tuple<bool,long,string> CreateAsn(TInAsn vAsn)
        {
            var o = new TInAsn
            {
                Code = Enum.GetName(typeof(EnumOrderType), EnumOrderType.ASN) + DateTime.Now.ToString(FormatString.DefaultFormat),
                RefCode = vAsn.RefCode ?? DateTime.Now.ToString(FormatString.DefaultFormat),
                WhId = vAsn.WhId,
                CustId = vAsn.CustId,
                BrandId = vAsn.BrandId,
                BatchNo = vAsn.BatchNo ?? DateTime.Now.ToString("yyyyMMdd"),
                BizCode = vAsn.BizCode,
                GoodsType = vAsn.GoodsType,
                Comment = vAsn.Comment,
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
            var r = false;
            try
            {
                wms.SaveChanges();
                this.setProxy(this.Mapper(o));
                r= wms.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                r= false;
            }

            return new Tuple<bool, long, string>(r,o.Id,"");
        }

        public bool UpdateAsn(TInAsn vAsn)
        {
            var tAsn = wms.TInAsns.Where(x => x.Id == vAsn.Id).FirstOrDefault();
            if (tAsn == null)
            {
                throw new Exception("asn is not exist.");
            }

            //可以修改的内容
            tAsn.RefCode = vAsn.RefCode;
            tAsn.WhId = vAsn.WhId;
            tAsn.IsCiq = vAsn.IsCiq;
            tAsn.Comment = vAsn.Comment;

            return wms.SaveChanges() > 0;
        }

        public bool Upload(IFormFile file, long id, string code)
        {
            ioService.basePath = this.Root;
            //保存文件
            DataTable dataTable = ioService.Import(file, "ASN", code);

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
            o.CartonQty = details.Where(x => !string.IsNullOrEmpty(x.Carton)).Distinct().Count();

            foreach (var d in details)
            {
                var n = new TInAsnD
                {
                    HId = id,
                    Sku = d.Sku,
                    Barcode = d.Barcode,
                    Qty = d.Qty,
                    IsDeleted = false,
                    CreatedBy = DefaultUser.UserName,
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
            return ioService.Export(code, "ASN", dt);
        }

        //
        // 调用验货服务生成验货单
        //
        public List<Tuple<bool, string>> Affirms(long[] ids)
        {
            var list = new List<Tuple<bool, string>>();
            var asns = wms.TInAsns
                       .Where(x => ids.Contains(x.Id) && x.Status == "None")
                       .ToList();
            if (!asns.Any())
            {
                foreach (var id in ids)
                {
                    list.Add(new Tuple<bool, string>(false, string.Format("{0}", id)));
                }
                return list;
            }
            else
            {
                //把排除掉的记录标记为错误
                foreach (var id in ids)
                {
                    if (!asns.Any(x => x.Id == id))
                        list.Add(new Tuple<bool, string>(false, string.Format("{0}", id)));
                }
            }

            //继续操作
            int i = 0;
            foreach (var asn in asns)
            {
                if (asn.Status == Enum.GetName(typeof(EnumStatus), EnumStatus.None))
                {
                    asn.Status = Enum.GetName(typeof(EnumStatus), EnumStatus.Audit);
                    this.setProxy(this.Mapper(asn));
                    asn.CheckStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
                    this.setOptProxy(this.OptMapper<TInAsn>(asn, asn.CheckStatus));
                    wms.Add(asnCheckService.Create(asn));
                    i++;
                    var r = wms.SaveChanges() > 0;
                    list.Add(new Tuple<bool, string>(r, asn.Code));
                }
            }

            return list;
        }

        public List<Tuple<bool, long, string>> Checks(long[] asnIds)
        {
            return asnCheckService.ChecksByAsn(asnIds);
        }
    }
}