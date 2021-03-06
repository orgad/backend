using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using dotnet_wms_ef.Auth.Models;
using dotnet_wms_ef.Auth.ViewModels;
using System.Text;

namespace dotnet_wms_ef.Auth.Services
{
    /// 校验用户的账号和密码, 生成Token
    public class LoginService
    {
        wmsauthContext auth = new wmsauthContext();

        //生成Token
        private string GenerateToken(VLogin user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Username, "TokenAuth"),
                new[] { new Claim("ID", user.ID.ToString()) }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }

        private bool CheckUser(VLogin user)
        {
            var isExists = false;
            // 密文 Pwd
            var loginUser = auth.TPermUsers.Where(x => x.LoginName == user.Username).FirstOrDefault();
            if (loginUser == null)
            {
                return false;
            }
            // 明文 user.Password
            var bytes = Encoding.Default.GetBytes(loginUser.Pwd);
            // 校验
            isExists = MD5Service.VerifyMd5Hash(MD5Service.MD5Hash, user.Password, loginUser.Pwd);

            return isExists;
        }

        public VToken Auth(VLogin user)
        {
            var exists = this.CheckUser(user);
            if (exists)
            {
                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;
                var token = GenerateToken(user, expiresIn);

                return new VToken
                {
                    StateCode = 1,
                    RequertAt = requestAt,
                    ExpiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
                    AccessToken = token
                };
            }
            else
            {
                return new VToken { StateCode = -1, Errors = "Username or password is invalid" };
            }
        }
    }
}