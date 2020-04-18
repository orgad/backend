using System;
using System.Linq;
using dotnet_wms_ef.Inbound.Models;
using dotnet_wms_ef.Mobile.ReturnIn.ViewModels;

namespace dotnet_wms_ef.ReturnIn.Services
{
    public class ReturnInService
    {
        wmsinboundContext wmsinbound = new wmsinboundContext();
        public bool Scan(VPkgScan pkg)
        {
            //需要校验的内容:包裹单号不能重复

            var r = wmsinbound.TInRnPkgs.Any(x => x.TrackingNo == pkg.TrackingNo);
            if (r)
                return false;

            TInRnPkg tPkg = new TInRnPkg
            {
                Courier = pkg.Courier,
                TrackingNo = pkg.TrackingNo
            };

            tPkg.CreatedBy = DefaultUser.UserName;
            tPkg.CreatedTime = DateTime.UtcNow;

            var rns = wmsinbound.TInRns.Where(x => x.TrackingNo == pkg.TrackingNo).ToList();
            if (rns != null)
            {
                foreach (var rn in rns)
                    rn.PkgStatus = 1;
            }
            wmsinbound.TInRnPkgs.Add(tPkg);

            return wmsinbound.SaveChanges() > 0;
        }
    }
}