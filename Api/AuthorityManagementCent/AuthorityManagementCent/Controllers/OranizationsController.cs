using System;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Managers;
using AuthorityManagementCent.Dto.Response;
using System.Collections.Generic;
using AuthorityManagementCent.Filters;

namespace AuthorityManagementCent.Controllers
{
    /// <summary>
    ///  组织管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OranizationsController : ControllerBase
    {
        public OranizationManager _OranizationManager;
        public ILogger<UserController> _Logger;
        public OranizationsController(OranizationManager oranizationManager, ILogger<UserController> Logger)
        {
            this._OranizationManager = oranizationManager;
            this._Logger = Logger;
        }


        /// <summary>
        /// 添加组织 
        /// </summary>
        /// <param name="oranization"></param>
        /// <returns></returns>
        [HttpPost("add")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> PlusOranizatin([FromBody]OranizationRequest oranization)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取权限列表:\r\n" + (oranization != null ? JsonHelpers.ToJSON(oranization) : ""));
            var response = new ResponseMessage();
            if (oranization == null)
            {
                _Logger.LogInformation($"用户：{users.UserName}获取权限列表,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "添加组织时，请求参数为空";
            }
            try
            {
                response = await _OranizationManager.PlusOranization(oranization);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})添加组织报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"添加组织报错:{el.Message}";
            }
            return response;
        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="oranization"></param>
        /// <returns></returns>
        [HttpPost("delte/{oranizationId}")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> DelOranizatin([FromRoute]string oranizationId)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 获取权限列表:\r\n" + (oranizationId != null ? JsonHelpers.ToJSON(oranizationId) : ""));
            var response = new ResponseMessage();
            if (oranizationId == null)
            {
                _Logger.LogInformation($"用户：{users.UserName}获取权限列表,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "删除组织时，请求参数为空";
            }
            try
            {
                response = await _OranizationManager.RemoveOranization(oranizationId);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})添加组织报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"添加组织报错:{el.Message}";
            }
            return response;
        }


        /// <summary>
        /// 查找组织信息
        /// </summary>
        /// <param name="oranizationId"></param>
        /// <returns></returns>
        [HttpGet("GetOranization/{oranizationId}")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage> GetOranization([FromRoute]string oranizationId)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 查找组织信息:\r\n" + (oranizationId != null ? JsonHelpers.ToJSON(oranizationId) : ""));
            var response = new ResponseMessage();
            if (oranizationId == null)
            {
                _Logger.LogInformation($"用户：{users.UserName}查找组织信息,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "查找组织信息，请求参数为空";
            }
            try
            {
                response = await _OranizationManager.GetOrgnization(oranizationId);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})查找组织信息报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"查找组织信息报错:{el.Message}";
            }
            return response;
        }


        /// <summary>
        /// 创建组织树状结构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("createTreeStructure/{id}")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage<List<TreeResponse>>> OranizationsTreeStructure([FromRoute]string id)
        {

            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 创建组织树状结构:\r\n" + (id != null ? JsonHelpers.ToJSON(id) : ""));
            var response = new ResponseMessage<List<TreeResponse>>();
            if (id == null)
            {
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "创建左侧菜单时，请求参数为空";

            }
            try
            {
                response = await _OranizationManager.CreatOranizationTree(id);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})添加组织报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"添加组织报错:{el.Message}";
            }
            return response;
        }


        /// <summary>
        /// 组织选择树
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("TreeSelect/{id}")]
        [JwtTokenAuthorize]
        public async Task<ResponseMessage<List<TreeSelectResponse>>> TreeSelect([FromRoute]string id)
        {
            var users = DataBaseUser.TokenModel;
            _Logger.LogInformation($"用户{users?.UserName ?? ""},其ID:({users?.Id ?? ""}) 创建组织树状结构:\r\n" + (id != null ? JsonHelpers.ToJSON(id) : ""));
            var response = new ResponseMessage<List<TreeSelectResponse>>();
            if (id == null)
            {
                _Logger.LogInformation($"用户：{users.UserName}创建组织树状结构,请求的参数为空。");
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "选择树，请求参数为空";
            }
            try
            {
                response = await _OranizationManager.CreatSelectTree(id);
            }
            catch (Exception el)
            {
                _Logger.LogError($"用户{users?.UserName ?? ""}({users?.Id ?? ""})创建组织树状结构报错：\r\n{el.ToString()}");
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"加载选择数失败，请联系管理员";
            }
            return response;
        }
    }


}
