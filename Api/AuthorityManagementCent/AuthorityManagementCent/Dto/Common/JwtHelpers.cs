using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace AuthorityManagementCent.Dto.Common
{

    /// <summary>
    /// JWY的生成和解析
    /// </summary>
    public class JwtHelpers
    {
        private static string SecurityKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1456789513";
        /// <summary>
        /// 发放Token
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        public static string IssueJWT(TokenModel tokenModel)
        {
            /*  
              issuer表示token 的发放者。
              audience表示接收者，如果你有多个客户端访问Api，可以利用这个字段区分不同的客户端。
              expires表示token的过期时间，防止token被盗后被恶意使用，过期后需要重新申请。
              claims包含了用户的标识
            */
            //赋值给Token
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(tokenModel.UserName, "TokenAuth"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,  DateTime.UtcNow.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                        new Claim(ClaimTypes.Name,tokenModel.UserName),
                        new Claim(ClaimTypes.Role,tokenModel.RoleName),
                        new Claim(ClaimTypes.GivenName,tokenModel.TrueName),
                        new Claim("Organization",tokenModel.OrganizationId),
                        new Claim(ClaimTypes.Sid,tokenModel.Id)
                }
            );
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityTokenHandler()
                .CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = "ZQY",
                    Audience = "PC",
                    SigningCredentials = creds,
                    Subject = identity,
                    Expires = expiresAt
                });
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
