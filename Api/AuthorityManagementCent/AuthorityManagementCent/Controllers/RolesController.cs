using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Dto.Response;
using AuthorityManagementCent.Filters;
using AuthorityManagementCent.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Controllers
{

    /// <summary>
    /// 角色管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly ILogger<RolesController> _Logger;
        private readonly RolesManager _RolesManager;
        public RolesController(ILogger<RolesController> Logger, RolesManager RolesManager)
        {
            this._Logger = Logger;
            this._RolesManager = RolesManager;
        }
        /// <summary>
        /// 获取角色列表
        /// </summary>       
        /// <returns></returns>
        [HttpPost("ListRoles")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> GettingRoles()
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取角色列表:\r\n");
            var response = new ResponseMessage();
            try
            {
                response = await _RolesManager.InforResponseList();
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})获取角色列表报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"获取角色列表报错:{el.Message}";
            }
            return response;
        }

        /// <summary>
        /// 添加角色
        /// </summary>       
        /// <returns></returns>
        [HttpPost("add")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> PulshRole(RolesRequest rolesRequest)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 添加/修改角色:\r\n" + (rolesRequest != null ? JsonHelpers.ToJSON(rolesRequest) : ""));
            var response = new ResponseMessage();
            try
            {
                response = await _RolesManager.AddRoles(rolesRequest);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})添加/修改角色报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"添加角色列表报错:{el.Message}";
            }
            return response;
        }



        /// <summary>
        /// 添加角色组织权限表
        /// </summary>       
        /// <returns></returns>
        [HttpPost("add/RolePermissions")]
        //[JwtTokenAuthorize]
        public async Task<ResponseMessage> PulshRolePermissions(RolePermissionsRequest rolesRequest)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取权限列表:\r\n" + (rolesRequest != null ? JsonHelpers.ToJSON(rolesRequest) : ""));
            var response = new ResponseMessage();
            try
            {
                response = await _RolesManager.AddRolePermissions(rolesRequest);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})添加角色列表报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"添加角色列表报错:{el.Message}";
            }
            return response;
        }



    }
}
