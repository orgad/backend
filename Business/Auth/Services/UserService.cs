using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotnet_wms_ef.Auth.Models;
using dotnet_wms_ef.Auth.ViewModels;

namespace dotnet_wms_ef.Auth.Services
{
    public class UserService
    {
        wmsauthContext wmsauth = new wmsauthContext();
        RSACSPService rSACSPService = new RSACSPService();

        public ICollection<VUser> PagedList()
        {
            return wmsauth.TPermUsers
            .Select(x => new VUser
            {
                Id = x.Id,
                LoginName = x.LoginName,
                TypeCode = x.TypeCode,
                NameCn = x.NameCn,
                NameEn = x.NameEn,
                Email = x.Email,
                ExpireAt = x.ExpireAt,
                CreatedBy = x.CreatedBy,
                CreatedTime = x.CreatedTime,
                LastModifiedBy = x.LastModifiedBy,
                LastModifiedTime = x.LastModifiedTime
            })
            .ToList();
        }

        public int Total()
        {
            return wmsauth.TPermUsers.Count();
        }

        public bool Create(VUserAdd user)
        {
            byte[] dataToEncrypt = Encoding.Default.GetBytes(user.Password);

            TPermUser tUser = new TPermUser();
            tUser.LoginName = user.UserName;
            tUser.Pwd = MD5Service.GetMd5Hash(MD5Service.MD5Hash, user.Password);
            tUser.NameCn = user.NameCn;
            tUser.NameEn = user.NameEn;
            tUser.TypeCode = user.TypeCode;
            tUser.ExpireAt = DateTime.UtcNow.AddYears(1);
            tUser.CreatedBy = DefaultUser.UserName;
            tUser.CreatedTime = DateTime.UtcNow;

            wmsauth.TPermUsers.Add(tUser);

            return wmsauth.SaveChanges() > 0;
        }

        public ICollection<VUser> GetUsersByRoleId(int roleId)
        {
            var userIds = wmsauth.TPermUserRoles.Where(x => x.RoleId == roleId).Select(x => x.UserId).ToList();
            var vusers = wmsauth.TPermUsers.Where(x => userIds.Contains(x.Id))
                        .Select(x => new VUser
                        {
                            Id = x.Id,
                            LoginName = x.LoginName,
                            TypeCode = x.TypeCode,
                            NameCn = x.NameCn,
                            NameEn = x.NameEn,
                            Email = x.Email,
                            ExpireAt = x.ExpireAt,
                            CreatedBy = x.CreatedBy,
                            CreatedTime = x.CreatedTime,
                            LastModifiedBy = x.LastModifiedBy,
                            LastModifiedTime = x.LastModifiedTime
                        }).ToList();
            return vusers;
        }

        public int getUserIdByLoginName(string loginName)
        {
            return this.getUserByLoginName(loginName).Id;
        }

        public string getUserLoginNameById(int userId)
        {
            return wmsauth.TPermUsers.Where(x => x.Id == userId).Select(x => x.LoginName).FirstOrDefault();
        }

        public TPermUser getUserByLoginName(string loginName)
        {
            return wmsauth.TPermUsers.Where(x => x.LoginName == loginName).FirstOrDefault();
        }
    }
}