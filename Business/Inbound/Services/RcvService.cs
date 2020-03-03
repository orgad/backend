using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef
{
    public class RcvService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();
        wmsproductContext wmsproduct = new wmsproductContext();

        //创建收货任务
        public void Create(TInOptlog opt)
        {
            //查询入库明细
            var inbound = wmsinbound.TInInbounds.Where(x => x.Id == opt.OrderId).FirstOrDefault();
            var asnId = inbound.AsnId;

            //查询到货明细
            var asndetail = wmsinbound.TInAsnDs.Where(x => x.HId == asnId && x.Barcode == opt.Barcode)
            .FirstOrDefault();

            if(asndetail==null)
            {
                throw new Exception("asndetail is null");
            }

            //从product获取skuid的信息
            var prodSku = wmsproduct.TProdSkus.Where(x => x.Barcode == opt.Barcode).FirstOrDefault();
            if (prodSku == null) throw new Exception("data is null");
            var sku = prodSku.Code;
            var skuid = prodSku.Id;

            //生成入库记录
            var inboundDetail = wmsinbound.TInInboundDs.Where(x => x.HId == opt.OrderId && x.Barcode == opt.Barcode).FirstOrDefault();
            if (inboundDetail != null)
            {
                inboundDetail.Qty += 1;
            }
            else
            {
                inboundDetail = new TInInboundD
                {
                    HId = opt.OrderId.Value,
                    SkuId = skuid,
                    Sku = sku,
                    Barcode = opt.Barcode,
                    Qty = 1,
                    CreatedBy = "rick.li",
                    CreatedTime = DateTime.UtcNow
                };
                wmsinbound.TInInboundDs.Add(inboundDetail);
            }

            //生成扫描记录
            opt.OptCode = "RCV";
            opt.OrderId = inbound.Id;
            opt.Qty = 1;
            opt.CreatedBy = "rick.li";
            opt.CreatedTime = DateTime.UtcNow;

            wmsinbound.Add(opt);
            wmsinbound.SaveChanges();
        }

        public List<TInInbound> PageList()
        {
            return this.Query().OrderByDescending(x => x.Id).ToList();
        }

        private IQueryable<TInInbound> Query()
        {
            return wmsinbound.TInInbounds.Where(
                x => x.Status == "None" && (
                 x.RStatus == "None" || x.RStatus == "Doing"));
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }
    }
}