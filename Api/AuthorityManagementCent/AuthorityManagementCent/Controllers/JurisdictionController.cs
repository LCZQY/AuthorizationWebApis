using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Managers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Filters;

namespace AuthorityManagementCent.Controllers
{
    /// <summary>
    /// 组织管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JurisdictionController : Controller
    {

        public JurisdictionManager _JurisdictionManager;
        public ILogger<UserController> _Logger;
        public JurisdictionController(JurisdictionManager JurisdictionManager, ILogger<UserController> Logger)
        {
            this._JurisdictionManager = JurisdictionManager;
            this._Logger = Logger;
        }


        /// <summary>
        /// 添加组织
        /// </summary>
        /// <param name="permissionRequest">基本信息</param>
        /// <returns></returns>
        [HttpPost("add")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> AddJurisdiction(PermissionitemRequest permissionRequest)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 添加组织:\r\n" + (permissionRequest != null ? JsonHelpers.ToJSON(permissionRequest) : ""));
            var response = new ResponseMessage();
            if (permissionRequest == null)
            {
                _Logger.LogInformation($"用户：{users.UserName}添加权限,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "请求参数为空";
            }
            try
            {
                return await _JurisdictionManager.InsertJurisdiction(permissionRequest);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户：{users.UserName }添加组织报错{ el.Message}\t\n");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = $"添加用户信息失败，请联系管理员.";
            }
            return response;
        }

        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="permissionitem"></param>
        /// <returns></returns>
        [HttpPost("getJurisdictionList")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> GetJurisdictionAsync(SearchPermissiontemRequest permissionitem)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取权限列表:\r\n" + (permissionitem != null ? JsonHelpers.ToJSON(permissionitem) : ""));
            var response = new ResponseMessage();
            if (permissionitem == null)
            {
                _Logger.LogInformation($"用户：{users.UserName}获取权限列表,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "请求参数为空";
            }
            try
            {
                return await _JurisdictionManager.ListPermissions(permissionitem);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户：{users.UserName }获取权限列表报错{ el.Message}\t\n");
                response.Code = ResponseCodeDefines.ModelStateInvalid;
                response.Message = $"获取权限信息报错：{ el.Message}";
            }
            return response;
        }      
    }
}
