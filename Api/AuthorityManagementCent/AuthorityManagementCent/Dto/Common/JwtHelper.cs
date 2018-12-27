//using AutoMapper.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Security.Principal;
//using System.Text;
//using System.Threading.Tasks;

//namespace AuthorityManagementCent.Dto.Common
//{

//    /// <summary>
//    /// JWY的生成和解析
//    /// </summary>
//    public class JwtHelper
//    {
//        private static string SecurityKe = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1456789513";
//        public static string IssueJWT()
//        {
//            string UserId = "1";
//            string Role = "admin";
//            //赋予Token的值
//            ClaimsIdentity identity = new ClaimsIdentity(
//                new GenericIdentity(users.userName, "TokenAuth") //用户名  
//                                                                 //给Token加上权限和角色 ？
//               , new[] {
//                        new Claim(JwtRegisteredClaimNames.Jti,UserId),
//                        new Claim("Role",Role),
//                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString(),ClaimValueTypes.Integer64)
//                }
//            );
//            var authTime = DateTime.UtcNow;
//            var expiresAt = authTime.AddDays(1);
//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKe));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            /*       issuer表示token 的发放者。
//                     audience表示接收者，如果你有多个客户端访问Api，可以利用这个字段区分不同的客户端。
//                     expires表示token的过期时间，防止token被盗后被恶意使用，过期后需要重新申请。
//                     claims包含了用户的标识
//            */
//            var securityToken = new JwtSecurityTokenHandler()
//                .CreateToken(new SecurityTokenDescriptor
//                {
//                    Issuer = "zqy.com",
//                    Audience = "pc.com",
//                    SigningCredentials = creds,
//                    Subject = identity,
//                    Expires = expiresAt
//                });
//            return new JwtSecurityTokenHandler().WriteToken(securityToken);
//        }

//    }
//}
