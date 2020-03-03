using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Views.ViewModels;

namespace dotnet_wms_ef
{
    public class InboundService
    {

        wmsinboundContext wmsinbound = new wmsinboundContext();

        wmsinventoryContext wmsinventory = new wmsinventoryContext();

        InventoryService inventoryService = new InventoryService();

        //创建入库单
        public TInInbound Create(TInAsn asn)
        {
            TInInbound r = new TInInbound();
            r.Code = asn.Code.Replace("ASN", "RCV");
            r.AsnId = asn.Id;
            r.BatchNo = asn.BatchNo;
            r.BizCode = asn.BizCode;
            r.WhId = asn.WhId;
            r.CustId = asn.CustId;
            r.BrandId = asn.BrandId;
            r.GoodsType = asn.GoodsType;
            r.SrcCode = asn.SrcCode;
            r.TransCode= asn.TransCode;
            r.TypeCode = "RCV";
            r.Status = "None";
            r.CreatedBy = "rick.li";
            r.CreatedTime = DateTime.UtcNow;
            return r;
        }
        
        //分页查询
        public List<TInInbound> PageList()
        {
            return this.Query().OrderByDescending(x => x.Id).ToList();
        }

        private IQueryable<TInInbound> Query()
        {
            return wmsinbound.TInInbounds;
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        public VInbound Details(long id)
        {
            var o = wmsinbound.TInInbounds.Where(x => x.Id == id).FirstOrDefault();

            var ds = wmsinbound.TInInboundDs.Where(x => x.HId == id).ToList();

            return new VInbound { Inbound = o, InboundDs = ds.Any() ? ds.ToArray() : null };
        }

        public List<TInOptlog> OptList()
        {
            return wmsinbound.TInOptlogs.ToList();
        }
        
        /*收货扫描记录*/
        public List<TInOptlog> Opt(long id)
        {
            return wmsinbound.TInOptlogs.Where(x=>x.OrderId == id).ToList();
        }
        public List<Tuple<long, bool>> RcvAffirm(long[] ids)
        {
            var list = new List<Tuple<long, bool>>();
            var inbounds = wmsinbound.TInInbounds.Where(x => ids.Contains(x.Id)).ToList();
            var inboundDs = wmsinbound.TInInboundDs.Where(x => ids.Contains(x.HId)).ToList();
            foreach (var inbound in inbounds)
            {
                var detailList = inboundDs.Where(x => x.HId == inbound.Id).ToArray();
                //生成库存记录
                inventoryService.Create(inbound.WhId, detailList);

                //修改单据状态
                inbound.RStatus = "Finished";

                var r1 = wmsinbound.SaveChanges() > 0;

                var r = new Tuple<long, bool>(inbound.Id, r1);
                list.Add(r);
            }
            return list;
        }
    }
}