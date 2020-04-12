using System;
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
        public bool Create(VUser user)
        {
            byte[] dataToEncrypt = Encoding.Default.GetBytes(user.Password);

            TPermUser tUser = new TPermUser();
            tUser.LoginName = user.Username;
            using (var RSA = new RSACryptoServiceProvider())
            {
                var p = RSA.ExportParameters(false);
                
                tUser.Pwd = Convert.ToBase64String(
                    RSACSPService.RSAEncrypt(dataToEncrypt, p, false)
                );
            }
            tUser.ExpireAt = DateTime.UtcNow.AddYears(1);
            tUser.CreatedBy = DefaultUser.UserName;
            tUser.CreatedTime = DateTime.UtcNow;

            wmsauth.TPermUsers.Add(tUser);

            return wmsauth.SaveChanges() > 0;
        }
    }
}