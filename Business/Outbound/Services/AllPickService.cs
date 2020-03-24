using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class AllPickService
    {
        WaveService waveService = new WaveService();
        PickService pickService = new PickService();
        public List<VPickingTaskList> List()
        {
            var list1 = waveService.PageList();
            var list2 = pickService.PageList(null);

            var list = new List<VPickingTaskList>();
            list.AddRange(list1.Select(x => new VPickingTaskList
            {
                Code = x.Code,
                TypeCode = "Wave",
                Status = "",
            }));

            list.AddRange(list2.Select(x => new VPickingTaskList
            {
                Code = x.Code,
                TypeCode = "Pick",
                Status = x.Status,
            }));

            return list;
        }

        public VPickAdvice Advice(long id, string TypeCode)
        {
            if (TypeCode == "Pick")
                return pickService.Advice(id);
            else
                return waveService.Advice(id);
        }

        public bool Scan(long id, string TypeCode, VScanBinRequest detail)
        {
             if (TypeCode == "Pick")
                return pickService.Scan(id,detail);
            else
                return waveService.Scan(id,detail);
        }
    }
}