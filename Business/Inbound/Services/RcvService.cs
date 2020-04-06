using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef
{
    public class RcvService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();
        SkuService skuService = new SkuService();

        StrategyService strategyService = new StrategyService();

        //创建收货记录
        public Tuple<bool, bool, string> CreateRcv(TInInboundRcv rcv)
        {
            //由于有超收的情况存在,无法判断是否全部收货完毕

            //从product获取skuid的信息
            var prodSku = skuService.GetSkuByBarcode(rcv.Barcode);
            if (prodSku == null) throw new Exception("barcode is not exists.");
            var sku = prodSku.Code;
            var skuid = prodSku.Id;

            var skuTotalQty = 0;

            //查询入库明细
            var inbound = wmsinbound.TInInbounds.Where(x => x.Id == rcv.HId).FirstOrDefault();
            var asnId = inbound.AsnId;
            var totalQty = inbound.Qty;

            var inboundDetail = wmsinbound.TInInboundDs.Where(x => x.HId == rcv.HId && x.Barcode == rcv.Barcode).FirstOrDefault();

            if (asnId > 0)
            {
                //查询到货明细
                var asnDetail = wmsinbound.TInAsnDs.Where(x => x.HId == asnId && x.Barcode == rcv.Barcode)
                .FirstOrDefault();
                if (asnDetail == null)
                {
                    throw new Exception("barcode" + rcv.Barcode + "not exists.");
                }
                skuTotalQty = asnDetail.Qty;

                // 核对扫描内容是否完整
                DoCheckList(inbound.WhId, inbound.CustId, inbound.BrandId, asnDetail, prodSku);

                //校验数量
                if (inboundDetail != null)
                {
                    //超收校验
                    skuTotalQty = DoCheckQty(asnDetail.Qty, inbound.WhId, inbound.CustId, inbound.BrandId, inboundDetail.Qty);
                    totalQty = totalQty - asnDetail.Qty + skuTotalQty;
                }
            }
            else
            {
                //盲收校验
                DoCheckBlind(inbound.WhId, inbound.CustId, inbound.BrandId);
            }

            //新增操作
            inbound.RStatus = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);
            var r = SaveSku(prodSku.Id, prodSku.Code, skuTotalQty, inbound.Id, inboundDetail, rcv);
            return new Tuple<bool, bool, string>(false, r.Item1, r.Item2);
        }


        public List<TInInbound> PageList()
        {
            return this.Query().OrderByDescending(x => x.Id).ToList();
        }

        private bool DoCheckList(int whId, int custId, int brandId, TInAsnD asnDetail, TProdSku sku)
        {
            //校验asn里面的内容和sku信息是否一致.
            var list = strategyService.CheckList(whId, custId, brandId);

            var p1 = Enum.GetName(typeof(EnumCheckSku), EnumCheckSku.Product);

            if (list.Contains(p1))
            {
                if (asnDetail.ProductCode != sku.ProductCode)
                    throw new Exception("product code is not eqals.");
            }
            return true;
        }
        private void DoCheckBlind(int whId, int custId, int brandId)
        {
            //无来源
            if (!strategyService.CheckAllBlind(whId, custId, brandId))
            {
                //不允许盲收
                throw new Exception("asnDetail is null");
            }
        }
        private int DoCheckQty(int asnQty, int whId, int custId, int brandId, int inboundQty)
        {
            //有来源
            var r2 = strategyService.CheckAllowOut(whId, custId, brandId);
            var alertQty = 0;
            if (r2.Item1 == true)
            {
                alertQty = Convert.ToInt32(Math.Floor(asnQty * (1 + r2.Item2)));
            }
            else
            {
                alertQty = asnQty;
            }
            //允许超收
            //获取已收货的数量
            if (inboundQty > alertQty)
            {
                alertQty = -1;
            }

            return alertQty;
        }

        private Tuple<bool, string> SaveSku(long skuId, string sku, int totalQty, long inboundId, TInInboundD inboundDetail, TInInboundRcv rcv)
        {
            var r = false;

            if (inboundDetail == null || inboundDetail.Qty + 1 <= totalQty)
            {
                //生成入库记录
                if (inboundDetail != null)
                {
                    inboundDetail.Qty += 1;
                    if (inboundDetail.Qty + 1 == totalQty)
                    {
                        r = true;
                    }
                }
                else
                {
                    inboundDetail = new TInInboundD
                    {
                        HId = inboundId,
                        SkuId = skuId,
                        Sku = sku,
                        Barcode = rcv.Barcode,
                        Qty = 1,
                        CreatedBy = DefaultUser.UserName,
                        CreatedTime = DateTime.UtcNow
                    };
                    wmsinbound.TInInboundDs.Add(inboundDetail);
                }

                //生成扫描记录
                rcv.HId = inboundId;
                rcv.Qty = 1;
                rcv.Sku = sku;
                rcv.SkuId = skuId;
                rcv.CreatedBy = DefaultUser.UserName;
                rcv.CreatedTime = DateTime.UtcNow;

                var data = string.Empty;
                wmsinbound.TInInboundRcvs.Add(rcv);

                try
                {
                    wmsinbound.SaveChanges();
                    data = string.Format("{0}/{1}", inboundDetail.Qty, totalQty);
                }
                catch (Exception ex)
                {
                    data = ex.InnerException.Message;
                }
                return new Tuple<bool, string>(r, data);
            }
            else
            {
                var data = string.Format("{0}/{1}", totalQty, totalQty);
                return new Tuple<bool, string>(true, data);
            }
        }

        private IQueryable<TInInbound> Query()
        {
            return wmsinbound.TInInbounds.Where(
                x => x.Status == Enum.GetName(typeof(EnumStatus), EnumStatus.None) && (
                 x.RStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init)
                   || x.RStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing)));
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }
    }
}