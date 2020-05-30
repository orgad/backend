using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Outbound.Models;

namespace dotnet_wms_ef.Services
{
    public partial class InventoryService
    {
        public TInvtD[] Allot(int whId, TOutD[] singleOutdetails)
        {
            var allotInvts = new List<TInvtD>();
            var groups = singleOutdetails.GroupBy(x => x.SkuId);

            //按照sku进行分组,获得分配的库存返回值
            foreach (var group in groups)
            {
                var singleSkuDetails = singleOutdetails.Where(x => x.SkuId == group.Key).ToList();
                //按单个sku进行库存分配
                var r = AllotBySku(group.Key, singleSkuDetails.ToArray());
                if (r != null && r.Any())
                    allotInvts.AddRange(r);
            }

            wmsinventory.SaveChanges();

            return allotInvts.ToArray();
        }
        private TInvtD[] AllotBySku(long skuId, TOutD[] singleSkuDetails)
        {
            var allotInvts = new List<TInvtD>();

            //找到某一个sku 的库存记录
            var o = wmsinventory.TInvts.Where(x => x.SkuId == skuId).FirstOrDefault();

            if (o == null)
            {
                throw new Exception("inventory is not exists.");
            }

            var leaveInvtQty = o.Qty - o.AllotQty - o.LockedQty;

            var totalQty = singleSkuDetails.Sum(x => x.Qty - x.MatchingQty ?? 0);

            if (leaveInvtQty == 0)
            {
                //没有可分配库存
                return null;
            }
            else if (leaveInvtQty >= totalQty)
            {
                //库存够分配的情况
                o.AllotQty += totalQty;
            }
            else
            {
                //库存部分分配的情况
                o.AllotQty += leaveInvtQty;
            }

            // 处理明细信息
            foreach (var detail in singleSkuDetails)
            {
                //返回库存明细信息
                var skuQty = detail.Qty;
                var invtDs = wmsinventory.TInvtDs.Where(x => x.SkuId == detail.SkuId && x.Qty - x.AllotQty - x.LockedQty > 0)
                            .ToList();
                if (invtDs.Any())
                {
                    if (skuQty > 0)
                    {
                        allotInvts.AddRange(AddAllotQty(skuQty, invtDs));
                    }
                }
            }

            return allotInvts.ToArray();
        }
        private List<TInvtD> AddAllotQty(int skuQty, List<TInvtD> invtds)
        {
            var list = new List<TInvtD>();

            var allQty = skuQty;

            foreach (var invtd in invtds)
            {
                var newInvtD = new TInvtD
                {
                    Id = invtd.Id,
                    HId = invtd.HId,
                    SkuId = invtd.SkuId,
                    Sku = invtd.Sku,
                    Barcode = invtd.Barcode,
                    Qty = allQty,
                    AllotQty = 0,
                    ZoneId = invtd.ZoneId,
                    ZoneCode = invtd.ZoneCode,
                    BinId = invtd.BinId,
                    BinCode = invtd.BinCode,
                };

                var canQty = invtd.Qty - invtd.AllotQty - invtd.LockedQty;
                if (canQty >= skuQty)
                {
                    invtd.AllotQty += skuQty;
                    newInvtD.AllotQty = skuQty;
                    list.Add(newInvtD);
                    break;
                }
                else
                {
                    //循环分配的情况
                    invtd.AllotQty += canQty;
                    skuQty -= canQty;
                    newInvtD.AllotQty = canQty;
                    list.Add(newInvtD);
                }
            }
            return list;
        }
    }
}
