using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Dto.Response;
using AuthorityManagementCent.Filters;
using AuthorityManagementCent.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Controllers
{
    /// <summary>
    /// 发放Token
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _Logger;
        private readonly TokenManager _UserInfoManager;

        public TokenController(
            ILogger<TokenController> logger,
            TokenManager userInfoManager
            )
        {
            this._Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._UserInfoManager = userInfoManager ?? throw new ArgumentNullException(nameof(userInfoManager));
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<ResponseMessage<string>> Tokens([FromBody] LoginRequest users)
        {
            _Logger.LogInformation($"{users.userName}获取Token中。");
            var response = new ResponseMessage<string>();
            if (users == null)
            {
                _Logger.LogInformation($"{users.userName}获取Token中,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "请求参数为空";
            }
            try
            {
                response = await _UserInfoManager.Exiexistence(users);
            }
            catch (Exception el)
            {
                _Logger.LogInformation($"{users.userName}获取Token，报错信息为:{el.Message}");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "请求Token时报错。";
            }
            return response;
        }


        /// <summary>
        /// 检查所属权限列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("listPermissionCheck")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage<PerUserResponse>> PermissionCheck()
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户：{users.UserName}，其ID:{ users.Id},验证所属所有权限列表");
            var response = new ResponseMessage<PerUserResponse>();
            try
            {
                var list = await _UserInfoManager.JurisdictionList(users.Id);
                var perUser = new PerUserResponse()
                {
                    PermissionList = list.Extension,
                    UserName = users.TrueName
                };
                response.Extension = perUser;
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户：{users.UserName }检查所属权限列表报错{ el.Message}\t\n");
                response.Code = ResponseCodeDefines.ModelStateInvalid;
                response.Message = $"检查所属权限列表失败：{ el.Message}";
            }
            return response;
        }

        [HttpPost("outLogin")]
        public ActionResult outLogin()
        {
            return BadRequest("请登陆");
        }
    }


}
