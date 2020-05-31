using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            .Select(x=>new VUser{
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

        public bool Create(VLogin user)
        {
            byte[] dataToEncrypt = Encoding.Default.GetBytes(user.Password);

            TPermUser tUser = new TPermUser();
            tUser.LoginName = user.Username;
            tUser.Pwd = MD5Service.GetMd5Hash(MD5Service.MD5Hash, user.Password);
            tUser.ExpireAt = DateTime.UtcNow.AddYears(1);
            tUser.CreatedBy = DefaultUser.UserName;
            tUser.CreatedTime = DateTime.UtcNow;

            wmsauth.TPermUsers.Add(tUser);

            return wmsauth.SaveChanges() > 0;
        }
    }
}