using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Managers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace AuthorityManagementCent.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public UserManager _UserManager;
        public ILogger<UserController> _Logger;

        public UserController(UserManager UserController, ILogger<UserController> Logger)
        {
            this._UserManager = UserController;
            this._Logger = Logger;
        }
        
        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="conditionSearch"></param>
        /// <returns></returns>
        [HttpPost("getUsersMessages")]
        public async Task<ResponseMessage> GetUsersMessageAsync(PageConditionSearch conditionSearch)
        {
            var response = new ResponseMessage();
            if (conditionSearch == null)
            {
                //_Logger.LogInformation($"{users.userName}获取Token中,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "请求参数为空";
            }
            try
            {
                return await _UserManager.GettingUsers(conditionSearch);
            }
            catch (Exception el)
            {
                response.Code = ResponseCodeDefines.ModelStateInvalid;
                response.Message = $"获取所有用户信息报错：{ el.Message}";
            }
            return response;
        }
    }
}
