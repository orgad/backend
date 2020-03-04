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
         private List<TStD> List(int whId,int custId,int brandId)
         {
             var list = new List<TStD>();
             var o = wmsinbound.TSt.Where(x=>x.WhId == whId && x.CustId ==custId && x.BrandId == brandId).FirstOrDefault();
             if(o!=null)
             {
                list = wmsinbound.TStD.Where(x=>x.HId == o.Id).OrderBy(x=>x.Seq) .ToList();
             }
             return list;
         }

         //获取当前节点的下一个节点
         public EnumInOperation NextFlow(int whId,int custId,int brandId,EnumInOperation currentFlow)
         {
             var cf = Enum.GetName(typeof(EnumInOperation),currentFlow);
             var list = List(whId,custId,brandId);
             var index = list.FindIndex(x=>x.OptCode == cf);
             var nf = list[index+1].OptCode;
             
             if(nf == Enum.GetName(typeof(EnumInOperation),EnumInOperation.Qc)) return EnumInOperation.Qc;
             if(nf == Enum.GetName(typeof(EnumInOperation),EnumInOperation.PutAway)) return EnumInOperation.PutAway;
             
            return EnumInOperation.None;
         }
    }
}