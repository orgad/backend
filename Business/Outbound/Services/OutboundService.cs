using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Business.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class OutboundService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        ProductService productService = new ProductService();
        public List<TOut> PageList(QueryOut queryOut)
        {
            return this.Query(queryOut).ToList();
        }

        public int TotalCount(QueryOut queryOut)
        {
            return this.Query(queryOut).Count();
        }

        private IQueryable<TOut> Query(QueryOut queryOut)
        {
            var query = wmsoutbound.TOuts;
            return query;
        }

        public VOutboundDetails Details(long outId)
        {
            var outbound = wmsoutbound.TOuts.Where(x => x.Id == outId).FirstOrDefault();
            var detailList = wmsoutbound.TOutDs.Where(x => x.HId == outId).ToArray();

            return new VOutboundDetails { Outbound = outbound, DetailList = detailList };
        }

        public List<Tuple<bool, string>> CreateOutFromDn(TOutDn dn)
        {
            var results = new List<Tuple<bool, string>>();
            var outbound = wmsoutbound.TOuts.Where(x => x.DnId == dn.Id).FirstOrDefault();
            if (outbound != null)
                results.Add(new Tuple<bool, string>(false, dn.Code + "is exist"));
            
            dn.DetailList = wmsoutbound.TOutDnDs.Where(x=>x.HId == dn.Id).ToList();

            var shops = dn.DetailList.Select(x => x.Store).ToList();
            if (shops != null && shops.Any())
            {
                var groups = dn.DetailList.GroupBy(x => x.Store);
                foreach (var group in groups)
                {
                    var detailList = dn.DetailList.Where(x => x.Store == group.Key).ToList();
                    results.Add(CreateOutbound(dn, group.Key, detailList));
                }
            }
            else
            {
                results.Add(CreateOutbound(dn, "", dn.DetailList.ToList()));
            }

            return results;
        }

        private Tuple<bool, string> CreateOutbound(TOutDn dn, string store, List<TOutDnD> list)
        {
            var outbound = new TOut
            {
                Code = dn.Code.Replace("Dn", "SHP"),
                BatchNo = dn.BatchNo,
                WhId = dn.WhId,
                CustId = dn.CustId,
                BrandId = dn.BrandId,
                DnId = dn.Id,
                BizCode = dn.BizCode,
                GoodsType = dn.GoodsType,
                TypeCode = "SHP",
                TransCode = "Outbound",
                SrcCode = "Interface",
                Store = store,
                Status = "None",
                IsDeleted = false,
                OrderPayment = dn.OrderPayment,
                Payment = dn.Payment,
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow
            };
            

            var detailList = new List<TOutD>();
            foreach (TOutDnD detail in list)
            {
                var prodSku = productService.GetSkuByBarcode(detail.Barcode);

                detailList.Add(new TOutD
                {
                    Qty = detail.Qty,
                    Carton = detail.Carton,
                    Barcode = detail.Barcode,
                    Sku = detail.Sku,
                    SkuId = prodSku.Id,
                    RetailPrice = detail.RetailPrice,
                    ActualPrice = detail.ActualPrice,
                    Discount = detail.Discount,
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow
                });
            }

            dn.Status = Enum.GetName(typeof(EnumStatus),EnumStatus.Audit);

            outbound.DetailList = detailList;

            wmsoutbound.TOuts.Add(outbound);

            var r = wmsoutbound.SaveChanges() > 0;

            return new Tuple<bool, string>(r, "");
        }

        public void Alot(long id)
        {
             var outbound = wmsoutbound.TOuts.Where(x=>x.Id == id).FirstOrDefault();

             //获取库存明细
        }
    }
}