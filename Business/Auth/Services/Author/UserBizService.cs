using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Auth.Models;

namespace dotnet_wms_ef.Auth.Services
{
    // 返回某个角色的数据权限
    public class UserBizService
    {
        wmsauthContext wmsauth = new wmsauthContext();
        BizService bizService = new BizService();

        //仓库,客户,品牌,门店
        public List<TPermBiz> GetBizsByUserId(int userId)
        {
            //首先获得
            var bizIds = wmsauth.TPermUserBizs.Where(x => x.UserId == userId).Select(x => x.BizId).ToArray();
            return bizService.GetBizs(bizIds);
        }

        public List<TPermBiz> GetBizsByLoginName(string loginName)
        {
            var bizIds = wmsauth.TPermUserBizs.Where(x => x.LoginName == loginName).Select(x => x.BizId).ToArray();
            return bizService.GetBizs(bizIds);
        }
    }
}