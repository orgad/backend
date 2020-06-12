using System;
using System.Collections.Generic;
using System.Linq;
using dotnet_wms_ef.Auth.Models;
using dotnet_wms_ef.Auth.ViewModels;

namespace dotnet_wms_ef.Auth.Services
{
    // 返回某个角色的数据权限
    public class UserBizService
    {
        wmsauthContext wmsauth = new wmsauthContext();
        BizService bizService = new BizService();
        UserService userService = new UserService();

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

        public List<VBiz> GetBizsByLoginName2(string loginName)
        {
            var bizIds = wmsauth.TPermUserBizs.Where(x => x.LoginName == loginName).Select(x => x.BizId).ToArray();
            return bizService.GetBizs(bizIds)
            .Select(x => new VBiz
            {
                WhId = x.WhId,
                WhCode = x.WhCode,
                CustId = x.CustId,
                CustCode = x.CustCode,
                BrandId = x.BrandId,
                BrandCode = x.BrandCode,
                BizCode = x.BizCode
            }).ToList();
        }

        public bool Create(int userId, TPermBiz[] bizs)
        {
            //首先找到已经存在的bizs,比对传入bizs
            //如果已存在的不包括传入的,删除
            var datas = wmsauth.TPermUserBizs.Where(x => x.UserId == userId).ToList();
            var userCode = userService.getUserLoginNameById(userId);
            //如果传入的不属于已存在的,新增
            var oldBizs = this.GetBizsByUserId(userId);

            //首先取交集合
            var items = oldBizs.Where(x => bizs.Select(x => x.Id).Contains(x.Id)).Select(y => y.Id).ToList();
            //找到需要删除的:old-roles存在,roles不存在
            var needDeletds = oldBizs.Where(x => !items.Contains(x.Id)).ToList();
            foreach (var item in needDeletds)
            {
                var data = datas.Where(x => x.BizId == item.Id).FirstOrDefault();
                if (data != null)
                    wmsauth.TPermUserBizs.Remove(data);
            }
            var needAdds = bizs.Where(x => !items.Contains(x.Id)).ToList();
            foreach (var item in needAdds)
            {
                var data = new TPermUserBiz
                {
                    UserId = userId,
                    LoginName = userCode,
                    BizId = item.Id,
                    BizCode = item.Code,
                    CreatedTime = DateTime.UtcNow,
                    CreatedBy = DefaultUser.UserName,
                };
                wmsauth.TPermUserBizs.Add(data);
            }

            return wmsauth.SaveChanges() > 0;
        }

    }
}