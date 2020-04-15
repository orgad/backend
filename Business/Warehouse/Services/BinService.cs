using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Models;
using dotnet_wms_ef.Warehouse.ViewModels;

namespace dotnet_wms_ef.Services
{
    public class BinService
    {
        wmswarehouseContext wms = new wmswarehouseContext();

        public TWhBin GetBinByCode(int whId, string binCode)
        {
            return wms.TWhBins.Where(x => x.WhId == whId && x.Code == binCode).FirstOrDefault();
        }

        public List<TWhBin> PageList(int page)
        {
            return wms.TWhBins.ToList();
        }

        public int TotalCount()
        {
            return wms.TWhBins.Count();
        }

        public bool Create(VWhBin whBin)
        {
            TWhBin tBin = new TWhBin();
            tBin.Code = whBin.Code;
            tBin.WhId = whBin.WhId;
            tBin.ZoneId = whBin.ZoneId;
            tBin.ZoneCode = whBin.ZoneCode;
            tBin.DutyId = whBin.DutyId;
            tBin.DutyCode = whBin.DutyCode;
            tBin.X = "";
            tBin.Y = "";
            tBin.Z = "";
            tBin.CreatedBy = DefaultUser.UserName;
            tBin.CreatedTime = DateTime.UtcNow;

            wms.TWhBins.Add(tBin);

            return wms.SaveChanges() > 0;
        }
    }
}