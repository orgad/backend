using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Auth.Models;

namespace dotnet_wms_ef.Auth.Services
{
    public class BizService
    {
        wmsauthContext wmsauth = new wmsauthContext();
        public List<TPermBiz> List()
        {
           return wmsauth.TPermBizs.ToList();
        }

        public List<TPermBiz> GetBizs(int[] ids)
        {
            return wmsauth.TPermBizs.Where(x=>ids.Contains(x.Id)).ToList();
        }
    }
}