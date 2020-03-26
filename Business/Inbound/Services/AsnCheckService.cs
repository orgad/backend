using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Microsoft.AspNetCore.Http;

using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;


namespace dotnet_wms_ef.Services
{
    public class AsnCheckService
    {
        wmsinboundContext wms = new wmsinboundContext();
        ImageIOService imageService = new ImageIOService();
        SkuService skuService = new SkuService();
        public string Root { get; set; }

        public TInCheck Create(TInAsn asn)
        {
            var o = new TInCheck();
            o.HId = asn.Id;
            o.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init);
            o.IsCiq = asn.IsCiq;
            o.Code = asn.Code.Replace(Enum.GetName(typeof(EnumOrderType), EnumOrderType.ASN),
                   Enum.GetName(typeof(EnumOrderType), EnumOrderType.CHK));
            o.CreatedBy = DefaultUser.UserName;
            o.CreatedTime = DateTime.UtcNow;
            return o;
        }

        public List<VAsnCheck> PageList(QueryAsnCheck queryAsnCheck)
        {
            return this.Query(queryAsnCheck)
                       .OrderByDescending(x => x.Id)
                       .Skip(queryAsnCheck.PageIndex)
                       .Take(queryAsnCheck.PageSize)
                       .ToList();
        }

        public int TotalCount(QueryAsnCheck queryAsnCheck)
        {
            return this.Query(queryAsnCheck).Count();
        }

        public VInCheck Get(long id)
        {
            var asnCheck = wms.TInChecks.Where(x => x.Id == id).FirstOrDefault();
            var asn = wms.TInAsns.Where(x => x.Id == asnCheck.HId).FirstOrDefault();
            return new VInCheck
            {
                Code = asnCheck.Code,
                asnCartonQty = asn.CartonQty,
                asnQty = asn.PieceQty,
                CartonQty = asnCheck.CartonQty,
                Qty = asnCheck.Qty,
                DamageCartonQty = asnCheck.DamageCartonQty,
                DamageQty = asnCheck.DamageQty,
            };
        }

        public TInCheckD[] DetailList(long id, string barcode)
        {
            var r = new List<TInCheckD>();
            if (!string.IsNullOrEmpty(barcode))
                r.Add(wms.TInCheckDs.Where(x => x.Id == id && x.Barcode == barcode).FirstOrDefault());
            else
                r = wms.TInCheckDs.Where(x => x.Id == id).ToList();
            return r.ToArray();
        }

        public bool Update(long id, TInCheck check)
        {
            var o = wms.TInChecks.Where(x => x.Id == id).FirstOrDefault();
            if (o != null)
            {
                o.CartonQty = check.CartonQty;
                o.Qty = check.Qty;
                o.DamageCartonQty = check.DamageCartonQty;
                o.DamageQty = check.DamageQty;
                o.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
                return wms.SaveChanges() > 0;
            }
            return false;
        }

        public List<VAsnCheck> TaskPageList(QueryAsnCheck queryAsnCheck)
        {
            return this.Query(queryAsnCheck)
                       .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) &&
                                 x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
                       .OrderByDescending(x => x.Id)
                       .Skip(queryAsnCheck.PageIndex)
                       .Take(queryAsnCheck.PageSize).ToList();
        }

        public int TaskTotalCount(QueryAsnCheck queryAsnCheck)
        {
            return this.Query(queryAsnCheck)
                   .Where(x => x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) &&
                                 x.Status == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
                    .Count();
        }

        private IQueryable<VAsnCheck> Query(QueryAsnCheck queryAsnCheck)
        {
            if (queryAsnCheck.PageSize == 0)
                queryAsnCheck.PageSize = 20;

            var query = (from check in wms.TInChecks
                         join asn in wms.TInAsns on check.HId equals asn.Id
                         select new VAsnCheck
                         {
                             Id = check.Id,
                             HId = check.HId,
                             Code = check.Code,
                             AsnCode = asn.Code,
                             IsCiq = check.IsCiq,
                             Status = check.Status,
                             AsnCartonQty = asn.CartonQty,
                             AsnQty = asn.PieceQty,
                             CartonQty = check.CartonQty,
                             Qty = check.Qty,
                             DamageCartonQty = check.DamageCartonQty,
                             DamageQty = check.DamageQty,
                             CreatedTime = check.CreatedTime,
                             CreatedBy = check.CreatedBy
                         })
                          as IQueryable<VAsnCheck>;

            return query;
        }

        public VAsnCheckDetails Details(long id)
        {
            var d = wms.TInChecks.Where(x => x.Id == id).FirstOrDefault();
            if (d == null) return null;
            var o = wms.TInAsns.Where(x => x.Id == d.HId).FirstOrDefault();
            var ds = wms.TInCheckDs.Where(x => x.HId == id).ToList();
            return new VAsnCheckDetails { Asn = o, AsnCheck = d, AsnCheckDs = ds.Any() ? ds.ToArray() : null };
        }

        public bool UploadsAndCreateDetail(long id, string barcode, IFormFileCollection files)
        {
            imageService.basePath = this.Root;

            //判断改条码是否已登记
            TInCheckD detail;
            detail = wms.TInCheckDs.Where(x => x.HId == id && x.Barcode == barcode).FirstOrDefault();
            if (detail == null)
            {
                detail = new TInCheckD();
            }
            //这个是单个条码的信息保存

            detail.HId = id;
            detail.Barcode = barcode;
            detail.TypeCode = "Damage";
            var sku = skuService.GetSkuByBarcode(barcode);
            if (sku != null)
            {
                detail.Sku = sku.Code;
                detail.SkuId = sku.Id;
            }
            detail.CreatedBy = DefaultUser.UserName;
            detail.CreatedTime = DateTime.UtcNow;

            int i = 1;
            //开始生成文件
            foreach (FormFile file in files)
            {
                var virtualPath = imageService.Upload(file, id + "-" + i);
                if (i == 1) { detail.Photo1 = virtualPath; detail.Comment1 = "全景图"; }
                if (i == 2) { detail.Photo2 = virtualPath; detail.Comment2 = "价签图"; }
                if (i == 3) { detail.Photo3 = virtualPath; detail.Comment3 = "破损1"; }
                if (i == 4) { detail.Photo4 = virtualPath; detail.Comment4 = "破损2"; }
                if (i == 5) { detail.Photo5 = virtualPath; detail.Comment5 = "破损3"; }
                i++;
            }

            wms.TInCheckDs.Add(detail);
            return wms.SaveChanges() > 0;
        }

        public bool Done(long id)
        {
            //更新验货单状态为已完成
            var o = wms.TInChecks.Where(x => x.Id == id).FirstOrDefault();
            var asn = wms.TInAsns.Where(x => x.Id == o.HId).FirstOrDefault();

            o.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Done);
            asn.CheckStatus = o.Status;

            return wms.SaveChanges() > 0;
        }

        public bool CreateDetails(long id, TInCheckD[] details)
        {
            foreach (var detail in details)
            {
                detail.HId = id;
                detail.CreatedBy = "rickli";
                detail.CreatedTime = DateTime.UtcNow;
            }
            wms.TInCheckDs.AddRange(details);

            return wms.SaveChanges() > 0;
        }
    }
}