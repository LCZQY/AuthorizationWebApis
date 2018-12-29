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
                TokenModel jwt = new TokenModel
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName= users.userName,
                    RoleName="admin",
                    TrueName ="郑强勇",
                    OrganizationId= "1",                    
                };
                response.Extension= JwtHelpers.IssueJWT(jwt);               
            }
            return response;
        }

    }
}
