using System;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Managers;


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
    }

}
