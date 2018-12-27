using System;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Stores.Interface;
using AuthorityManagementCent.Dto.Common;
using System.Security.Claims;
using System.Security.Principal;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AuthorityManagementCent.Managers
{

    /// <summary>
    /// 登陆信息
    /// </summary>
    public class TokenManager
    {
        private readonly ITokenStore _IUserInfo;
        public IConfiguration _Configuration { get; }

        public TokenManager(ITokenStore IUserInfo, IConfiguration configuration)
        {
            this._IUserInfo = IUserInfo;
            this._Configuration = configuration;        
        }

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<string>> Exiexistence(LoginRequest users)
        {
            var response = new ResponseMessage<string>();
            var returnUsers = await _IUserInfo.IExiexistence(users);
            if (returnUsers == null)
            {
                response.Code = ResponseCodeDefines.NotFound;
                response.Message = "该用户名不存在";
                return response;
            }
            if (returnUsers.PasswordHash != users.passWord)
            {
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "密码输入错误";
                return response;
            }
            else
            {
                string UserId = "1";
                string Role = "admin";
                response.Code = ResponseCodeDefines.SuccessCode;
                //赋予Token的值
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(users.userName, "TokenAuth") //用户名  
                   //给Token加上权限和角色 ？
                   , new[] {
                        new Claim(JwtRegisteredClaimNames.Jti,UserId),
                        new Claim("Role",Role),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString(),ClaimValueTypes.Integer64)
                    }
                );
                var authTime = DateTime.UtcNow;
                var expiresAt = authTime.AddDays(1);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._Configuration["JWT:SecurityKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                /*       issuer表示token 的发放者。
                         audience表示接收者，如果你有多个客户端访问Api，可以利用这个字段区分不同的客户端。
                         expires表示token的过期时间，防止token被盗后被恶意使用，过期后需要重新申请。
                         claims包含了用户的标识
                */
                var securityToken = new JwtSecurityTokenHandler()
                    .CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = "zqy.com",
                        Audience = "pc.com",
                        SigningCredentials = creds,
                        Subject = identity,
                        Expires = expiresAt
                    });
                response.Extension = new JwtSecurityTokenHandler().WriteToken(securityToken);             
            }
            return response;
        }

    }
}
