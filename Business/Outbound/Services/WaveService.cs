using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class WaveService
    {
        wmsoutboundContext wmsoutbound = new wmsoutboundContext();

        ProductService productService = new ProductService();

        BinService binService = new BinService();

        PickService pickService = new PickService();

        RecheckService recheckService = new RecheckService();

        OutStrategyService strategyService = new OutStrategyService();

        public List<TOutWave> PageList()
        {
            return this.Query().ToList();
        }

        public IQueryable<TOutWave> Query()
        {
            return wmsoutbound.TOutChecks as IQueryable<TOutWave>;
        }

        public int TotalCount()
        {
            return this.Query().Count();
        }

        public VWaveDetails Details(long id)
        {
            var wave = wmsoutbound.TOutWaves.Where(x => x.Id == id).FirstOrDefault();
            var detailList = wmsoutbound.TOutPicks.Where(x => x.WaveId == id).ToList();
            return new VWaveDetails
            {
                Wave = wave,
                DetailList = detailList
            };
        }

        public bool CreateWaveAuto(long whId, long custId, long brandId)
        {
            //获取波次策略
            var st = strategyService.WaveSt(whId, custId, brandId);

            //查找满足条件的单据
            var outbounds = wmsoutbound.TOuts.Where(x => x.WhId == whId && x.CustId == custId && x.BrandId == brandId
                            && x.AllotStatus == 2 && x.PickStatus == "None")
                            .ToList();

            var waveSize = st.WaveSize;

            for (int i = 0; i < outbounds.Count(); i += waveSize)
            {
                //产生波次
                var wave = new TOutWave
                {
                    Code = "WAV" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    WhId = whId,
                    Size = waveSize,
                    //Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init),
                    CreatedBy = DefaultUser.UserName,
                    CreatedTime = DateTime.UtcNow,
                };
                //产生拣货单和拣货明细
                var prePicks = outbounds.Skip(i).Take(waveSize).ToList();
                var ids = prePicks.Select(x => x.Id).ToList();
                var prePickDetailList = wmsoutbound.TOutDs.Where(x => ids.Contains(x.HId)).ToList();
                foreach (var prePick in prePicks)
                {
                    pickService.CreatePick(prePick);
                }
            }

            return wmsoutbound.SaveChanges() > 0;
        }

        public void CreateWave(long whId, long[] outboundIds)
        {
            var outbounds = wmsoutbound.TOuts.Where(x => outboundIds.Contains(x.Id)
                           && x.AllotStatus == 2 && x.PickStatus == "None")
                           .ToList();
            var wave = new TOutWave
            {
                Code = "WAV" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                WhId = whId,
                Size = outbounds.Count(),
                //Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Init),
                CreatedBy = DefaultUser.UserName,
                CreatedTime = DateTime.UtcNow,
            };
            foreach (var outbound in outbounds)
            {
                pickService.CreatePick(outbound);
            }

            wmsoutbound.SaveChanges();
        }

        public bool Scan(long waveId, VScanBinRequest detail)
        {
            var pick = wmsoutbound.TOutPicks.Where(x => x.WaveId == waveId).FirstOrDefault();
            if (pick == null)
            {
                throw new Exception("pick is not exist.");
            }

            //获取SKU信息
            var prodSku = productService.GetSkuByBarcode(detail.Barcode);
            if (prodSku == null)
            {
                throw new Exception("barcode is not exist.");
            }

            //新增拣货明细
            var pickDetail = wmsoutbound.TOutPickDs.Where(x => x.HId == pick.Id && x.Barcode == detail.Barcode).FirstOrDefault();
            if (pickDetail == null)
            {
                pickDetail = new TOutPickD
                {
                    HId = pick.Id,
                };
            }

            if (pick.FirstScanAt == null)
                pick.FirstScanAt = DateTime.UtcNow;

            pick.LastScanAt = DateTime.UtcNow;

            pick.Qty += 1;

            pick.Status = Enum.GetName(typeof(EnumOperateStatus), EnumOperateStatus.Doing);

            //获取货区货位信息
            var zoneBin = binService.GetBinByCode(pick.WhId, detail.BinCode);

            pickDetail.ActBinId = zoneBin.Id;
            pickDetail.ActBinCode = detail.BinCode;
            pickDetail.Qty = 1;
            pickDetail.ActZoneCode = zoneBin.ZoneCode;
            pickDetail.ActZoneId = zoneBin.ZoneId;
            pickDetail.IsPicked = true;
            pickDetail.LastModifiedBy = DefaultUser.UserName;
            pickDetail.LastModifiedTime = DateTime.UtcNow;

            if (pickDetail.Id == 0)
            {
                wmsoutbound.TOutPickDs.Add(pickDetail);
            }

            return wmsoutbound.SaveChanges() > 0;
        }

        public VPickAdvice Advice(long waveId)
        {
            var pick = wmsoutbound.TOutPicks.Where(x => x.WaveId == waveId).FirstOrDefault();

            //找到已经存在的拣货记录
            var detailList = wmsoutbound.TOutPickDs.Where(x => x.HId == pick.Id);

            var binCodes = detailList.Where(x => !x.IsPicked).Select(x => x.BinCode).OrderBy(x => x).Distinct();

            //查询当前货位的barcode列表
            var binCode = binCodes.FirstOrDefault();

            var barcodes = detailList.Select(x => x.Barcode).Distinct().ToArray();

            return new VPickAdvice { BinCode = binCode, Barcodes = barcodes };
        }

        public bool Affirms(long[] ids)
        {
            foreach (var id in ids)
            {
                //批量生成复核单
                Affirm(id);
            }
            return true;
        }

        private void Affirm(long waveId)
        {
            //找到波次单对应的拣货单
            var picks = wmsoutbound.TOutPicks.Where(x => x.WaveId == waveId).ToList();
            var pickIds = picks.Select(x => x.Id).ToArray();

            //调用拣货单批量全部确认接口
            recheckService.Affirms(pickIds);
        }
    }
}