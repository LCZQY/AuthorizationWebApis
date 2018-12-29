using System;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Managers;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using AuthorityManagementCent.Filters;

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
        public async Task<ResponseMessage<string>> Tokens([FromBody]LoginRequest users)
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

        [HttpPost("get")]
        [JwtTokenAuthorize]
        public ActionResult get()
        {
            var UseInfo = DataBaseUser.TokenModel;
            if (UseInfo == null)
            {
                return BadRequest("请登录！");
            }
            else
            {
                return Ok(UseInfo);
            }
        }

        [HttpPost("outLogin")]
        public ActionResult outLogin()
        {
            return BadRequest("请登陆");
        }
    }


}
