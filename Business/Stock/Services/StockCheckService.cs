using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Services;
using dotnet_wms_ef.Stock.Models;
using dotnet_wms_ef.Stock.ViewModels;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Stock.Services
{
    public class StockCheckService
    {
        wmsstockContext wmsstock = new wmsstockContext();
        SkuService skuService = new SkuService();
        public List<TInvtCheck> PageList()
        {
            return this.Query().ToList();
        }

        public int Total()
        {
            return this.Query().Count();
        }

        public List<TInvtCheck> TaskPageList()
        {
            return this.Query()
            .Where(x => x.ScanStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                        x.ScanStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
            .ToList();
        }

        public int TaskTotal()
        {
            return this.Query()
              .Where(x => x.ScanStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing) ||
                        x.ScanStatus == Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init))
            .Count();
        }

        private IQueryable<TInvtCheck> Query()
        {
            return wmsstock.TInvtChecks.OrderByDescending(x => x.Id)
            as IQueryable<TInvtCheck>;
        }

        public VStockCheckDetails Details(long stockCheckId)
        {
            var o = wmsstock.TInvtChecks.Where(x => x.Id == stockCheckId).FirstOrDefault();
            var detailList = wmsstock.TInvtCheckDs.Where(x => x.Id == stockCheckId).ToList();

            return new VStockCheckDetails
            {
                StockCheck = o,
                Details = detailList
            };
        }

        public Tuple<bool,long,string> Create(TInvtCheck vCheck)
        {
            TInvtCheck tCheck = new TInvtCheck();
            tCheck.TypeCode = vCheck.TypeCode; 
            tCheck.TypeMode = vCheck.TypeMode;
            tCheck.CreatedBy = DefaultUser.UserName;
            tCheck.Status = Enum.GetName(typeof(EnumStatus),EnumStatus.None);
            tCheck.ScanStatus = Enum.GetName(typeof(EnumOperateStatus),EnumOperateStatus.Init);
            tCheck.CreatedTime = DateTime.UtcNow;
            wmsstock.TInvtChecks.Add(tCheck);
            var r = wmsstock.SaveChanges()>0;

            return new Tuple<bool, long, string>(r,tCheck.Id,"");
        }

        public void Audits(long[] ids)
        {
            foreach (var id in ids)
            {
                Audit(id);
            }
        }

        private void Audit(long id)
        {
            //将库存数据加入到盘点明细中(仅物料时使用)
        }

        public VScanResponse Scan(long id, VScanRequest request)
        {
            var response = new VScanResponse();
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);
            if (prodSku == null)
            {
                throw new Exception("barcode is not exits");
            }

            //扫描货位和条码
            TInvtCheckD detail = new TInvtCheckD
            {
                HId = id,
                Barcode = request.Barcode,
                Carton = request.Carton,
                Qty = 1
            };

            wmsstock.TInvtCheckDs.Add(detail);

            wmsstock.SaveChanges();

            return response;
        }

        public void ScanAndCheck(long id, VScanRequest request)
        {
            var prodSku = skuService.GetSkuByBarcode(request.Barcode);
            if (prodSku == null)
            {
                throw new Exception("barcode is not exits");
            }

            //应该把扫描记录单独记录在一个表里面,然后通过扫描的结果和存在的记录进行对比
        }
    }
}