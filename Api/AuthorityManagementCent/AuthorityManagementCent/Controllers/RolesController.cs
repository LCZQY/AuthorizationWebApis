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
        /// 该权限的所有组织范围
        /// </summary>       
        /// <returns></returns>
        [HttpGet("getPermisionScopeList/{permissionId}")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> PermisionScopeList(string permissionId)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 该权限的所有组织范围:\r\n");
            var response = new ResponseMessage();
            try
            {
                response = await _RolesManager.GetPermisionScopeList(permissionId);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 该权限的所有组织范围报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"该权限的所有组织范围报错:{el.Message}";
            }
            return response;
        }

        /// <summary>
        /// 角色的所有权限项
        /// </summary>       
        /// <returns></returns>
        [HttpGet("getRolePermisionList/{roleid}")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> RolePermisionList(string roleid)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取角色的所有权限项:\r\n");
            var response = new ResponseMessage();
            try
            {
                response = await _RolesManager.GetRolePermisionList(roleid);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取角色的所有权限项报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"获取角色的所有权限项报错:{el.Message}";
            }
            return response;
        }

        /// <summary>
        /// 用户的所有角色
        /// </summary>       
        /// <returns></returns>
        [HttpGet("getUserRolesList/{useid}")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> UserRolesList(string useid)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取对应用户的所有角色:\r\n");
            var response = new ResponseMessage();
            try
            {
                response = await _RolesManager.GetUserRolesList(useid);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取对应用户的所有角色报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"获取对应用户的所有角色报错:{el.Message}";
            }
            return response;
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
        /// 删除角色
        /// </summary>       
        /// <returns></returns>
        [HttpPost("delete")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> DeleteRoles([FromBody]List<string> rolesRequest)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 删除角色:\r\n" + (rolesRequest != null ? JsonHelpers.ToJSON(rolesRequest) : ""));
            var response = new ResponseMessage();
            try
            {
                response = await _RolesManager.DeletRoleAsync(rolesRequest);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})删除角色报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"删除角色报错:{el.Message}";
            }
            return response;
        }


        /// <summary>
        /// 添加角色组织权限表
        /// </summary>       
        /// <returns></returns>
        [HttpPost("add/RolePermissions")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> PulshRolePermissions(RolePermissionsRequest rolesRequest)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 添加角色组织权限表:\r\n" + (rolesRequest != null ? JsonHelpers.ToJSON(rolesRequest) : ""));
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

        /// <summary>
        /// 添加用户角色表
        /// </summary>       
        /// <returns></returns>
        [HttpPost("add/UserRoles")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> PulshUserRole(UserRolesRequest rolesRequest)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 添加用户角色表:\r\n" + (rolesRequest != null ? JsonHelpers.ToJSON(rolesRequest) : ""));
            var response = new ResponseMessage();
            try
            {
                response = await _RolesManager.AddUserRoles(rolesRequest);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})添加用户角色表报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"添加用户角色表报错:{el.Message}";
            }
            return response;
        }

    }
}
