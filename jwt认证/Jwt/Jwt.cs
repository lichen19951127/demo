using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Jwt
{
    /// <summary>
    /// 加密解密的实现类
    /// </summary>
    public class Jwt : IJwt
    {
        private IConfiguration _configuration;
        private string _base64Secret;
        private JwtConfig _jwtConfig = new JwtConfig();
        public static List<string> InvalidateTokens = new List<string>();
        public Jwt(IConfiguration configration)
        {
            this._configuration = configration;
            configration.GetSection("Jwt").Bind(_jwtConfig);
            GetSecret();
        }
        /// <summary>
        /// 获取到加密串
        /// </summary>
        private void GetSecret()
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes("salt");
            byte[] messageBytes = encoding.GetBytes(this._jwtConfig.SecretKey);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                this._base64Secret = Convert.ToBase64String(hashmessage);
            }
        }
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="Claims"></param>
        /// <returns></returns>
        public string GetToken(IDictionary<string, string> Claims, string OldToken = null)
        {
            List<Claim> claimsAll = new List<Claim>();
            foreach (var item in Claims)
            {
                claimsAll.Add(new Claim(item.Key, item.Value ?? ""));
            }
            var symmetricKey = Convert.FromBase64String(this._base64Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience,
                Subject = new ClaimsIdentity(claimsAll),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(this._jwtConfig.Lifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey),
                                           SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            if (!string.IsNullOrEmpty(OldToken))//执行旧Token过期
            {
                if (!InvalidateTokens.Contains(OldToken))
                {
                    InvalidateTokens.Add(OldToken);
                }
            }
            return tokenHandler.WriteToken(securityToken);
        }
        public bool ValidateToken(string Token, out Dictionary<string, string> Clims)
        {
            Clims = new Dictionary<string, string>();
            if (InvalidateTokens.Contains(Token))
            {
                return false;
            }
            ClaimsPrincipal principal = null;
            if (string.IsNullOrWhiteSpace(Token))
            {
                return false;
            }
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var jwt = handler.ReadJwtToken(Token);
                if (jwt == null)
                {
                    return false;
                }
                var secretBytes = Convert.FromBase64String(this._base64Secret);
                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience
                    ValidateLifetime = this._jwtConfig.ValidateLifetime,//是否验证失效时间
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    ValidAudience = this._jwtConfig.Audience,
                    ValidIssuer = this._jwtConfig.Issuer
                };
                SecurityToken securityToken;
                principal = handler.ValidateToken(Token, validationParameters, out securityToken);
                foreach (var item in principal.Claims)
                {
                    Clims.Add(item.Type, item.Value);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }


        public bool InvalidateToken(string Token)
        {
            if (!InvalidateTokens.Contains(Token))
            {
                InvalidateTokens.Add(Token);
            }
            return true;
        }
    }
}
