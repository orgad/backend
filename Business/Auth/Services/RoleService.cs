using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Auth.Models;

namespace dotnet_wms_ef.Auth.Services
{
    public class RoleService
    {
        wmsauthContext wmsauth = new wmsauthContext();
        public ICollection<TPermRole> PagedList()
        {
            return wmsauth.TPermRoles.ToList();
        }

        public int Total()
        {
            return wmsauth.TPermRoles.Count();
        }

        public ICollection<TPermBiz> PagedBizList()
        {
            return wmsauth.TPermBizs.ToList();
        }

        public int BizTotal()
        {
            return wmsauth.TPermBizs.Count();
        }
    }
}