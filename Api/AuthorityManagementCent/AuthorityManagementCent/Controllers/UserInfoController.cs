using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Managers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace AuthorityManagementCent.Controllers
{
    /// <summary>
    /// 发放Token
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ILogger<UserInfoController> _Logger;
        private readonly UserInfoManager _UserInfoManager;

      
        public UserInfoController(
            ILogger<UserInfoController> Logger,
            UserInfoManager UserInfoManager
            )
        {
            this._Logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            this._UserInfoManager = UserInfoManager ?? throw new ArgumentNullException(nameof(UserInfoManager));
        }

        [HttpGet("get")]
        public string get()
        {
            return "200";
        }

        /// <summary>
        /// 测试方法一
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        [HttpPost("token")]
        public async Task<ResponseMessage> Tokens([FromBody]UsersRequest users)
        {

            _Logger.LogInformation($"{users.userName}获取Token中。");
            var response = new ResponseMessage();
            if (users ==  null)
            {
                _Logger.LogInformation($"{users.userName}获取Token中,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "请求参数为空";
            }

           // if (await _UserInfoManager.Exiexistence(users))
            {
               // return response;

            }
           // else
            {
                _Logger.LogInformation($"{users.userName}获取Token中,该用户名不存在，请求参数为:{ JsonConvert.SerializeObject(users)}");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "请求参数为空";         
            }
            return response;

        }
    }
}
