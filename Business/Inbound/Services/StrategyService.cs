using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;

namespace dotnet_wms_ef.Services
{
    // 入库流程控制
    public class StrategyService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();
        //读取当前单据对应的策略
        private List<TStD> List(int whId, int custId, int brandId)
        {
            var list = new List<TStD>();
            var o = wmsinbound.TSts.Where(x => x.WhId == whId && x.CustId == custId && x.BrandId == brandId).FirstOrDefault();
            if (o != null)
            {
                list = wmsinbound.TStDs.Where(x => x.HId == o.Id).OrderBy(x => x.Seq).ToList();
            }
            return list;
        }

        //获取当前节点的下一个节点
        public EnumInOperation NextFlow(int whId, int custId, int brandId, EnumInOperation currentFlow)
        {
            var cf = Enum.GetName(typeof(EnumInOperation), currentFlow);
            var list = List(whId, custId, brandId);
            if (list.Any())
            {
                var index = list.FindIndex(x => x.OptCode == cf);
                var nf = list[index + 1].OptCode;
                if (nf == Enum.GetName(typeof(EnumInOperation), EnumInOperation.Qc)) return EnumInOperation.Qc;
                if (nf == Enum.GetName(typeof(EnumInOperation), EnumInOperation.PutAway)) return EnumInOperation.PutAway;
            }
            return EnumInOperation.None;
        }

        //忙收
        public bool CheckAllBlind(int whId, int custId, int brandId)
        {
            var rcvSt = wmsinbound.TSts.Where(x => x.WhId == whId && x.CustId == custId && x.BrandId == brandId)
            .FirstOrDefault();
            return wmsinbound.TStRcvs.Where(x => x.HId == rcvSt.Id).Select(x => x.AllowBlind).FirstOrDefault();
        }

        //超收 
        public Tuple<bool, decimal> CheckAllowOut(int whId, int custId, int brandId)
        {
            //查策略主表
            var rcvSt = wmsinbound.TSts.Where(x => x.WhId == whId && x.CustId == custId && x.BrandId == brandId)
            .FirstOrDefault();
            if (rcvSt == null)
                return new Tuple<bool, decimal>(false, 0);

            //查策略明细
            var o = wmsinbound.TStRcvs.Where(x => x.HId == rcvSt.Id).FirstOrDefault();

            if (o != null)
                return new Tuple<bool, decimal>(o.AllowOut, o.OutRate);
            else
                return new Tuple<bool, decimal>(false, 0);
        }

        //校验字段
        public List<string> CheckList(int whId, int custId, int brandId)
        {
            var list = new List<string>();
            var rcvSt = wmsinbound.TSts.Where(x => x.WhId == whId && x.CustId == custId && x.BrandId == brandId)
            .FirstOrDefault();
            if (rcvSt != null)
            {
                var o = wmsinbound.TStRcvs.Where(x => x.HId == rcvSt.Id).Select(x => x.CheckList).FirstOrDefault();
                if (string.IsNullOrEmpty(o))
                    return list;
                else
                    return o.Split(',').ToList();
            }
            else
            {
                return list;
            }
        }
    }
}