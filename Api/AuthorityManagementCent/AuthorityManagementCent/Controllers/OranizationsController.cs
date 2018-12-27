using System;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Managers;
using AuthorityManagementCent.Dto.Response;
using System.Collections.Generic;

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
        /// 添加组织 【存储到扩展表中？？】
        /// </summary>
        /// <param name="oranization"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<ResponseMessage> PlusOranizatin([FromBody]OranizationRequest oranization)
        {
            var response = new ResponseMessage();
            if (oranization == null)
            {
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "添加组织时，请求参数为空";
            }
            try
            {
                response = await _OranizationManager.PlusOranization(oranization);
            }
            catch (Exception el)
            {
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"添加组织报错:{el.Message}";
            }
            return response;
        }



        /// <summary>
        /// 创建组织树状结构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("createTreeStructure/{id}")]
        public async Task<ResponseMessage<List<TreeResponse>>> OranizationsTreeStructure([FromRoute]string id) {

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
        public async Task<ResponseMessage<List<TreeSelectResponse>>> TreeSelect([FromRoute]string id)
        {
            var response = new ResponseMessage<List<TreeSelectResponse>>();
            if (id == null)
            {
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "选择树，请求参数为空";
            }
            try
            {
                response = await _OranizationManager.CreatSelectTree(id);
            }
            catch (Exception el)
            {
                response.Code = ResponseCodeDefines.ArgumentNullError;
                response.Message = $"加载选择数失败，请联系管理员";
            }
            return response;
        }
    }


}
