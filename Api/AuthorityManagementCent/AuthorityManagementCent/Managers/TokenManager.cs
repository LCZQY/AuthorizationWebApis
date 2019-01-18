using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Response;
using AuthorityManagementCent.Stores.Interface;
using AuthorityManagementCent.Dto.Common;
using Microsoft.EntityFrameworkCore;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;

namespace AuthorityManagementCent.Managers
{

    /// <summary>
    /// 登陆信息
    /// </summary>
    public class TokenManager
    {
        private readonly ITokenStore _IUserInfo;
        private readonly IRolesStore _IRolesStore;
        public TokenManager(ITokenStore IUserInfo, IRolesStore IRolesStore)
        {            
            this._IUserInfo = IUserInfo;
            this._IRolesStore = IRolesStore;
        }

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<string>> Exiexistence(LoginRequest users)
        {
            var response = new ResponseMessage<string>();
            var returnUsers = await _IUserInfo.IExiexistence(users);
            if (returnUsers == null)
            {
                response.Code = ResponseCodeDefines.NotFound;
                response.Message = "该用户名不存在";
                return response;
            }
            if (returnUsers.PasswordHash != users.passWord)
            {
                response.Code = ResponseCodeDefines.NotAllow;
                response.Message = "密码输入错误";
                return response;
            }
            else
            {                
                TokenModel jwt = new TokenModel
                {
                    Id = returnUsers.Id,
                    RoleName="",
                    UserName = users.userName,                  
                    TrueName = returnUsers.TrueName,
                    OrganizationId = returnUsers.OrganizationId,
                };
                response.Extension= JwtHelpers.IssueJWT(jwt);               
            }
            return response;
        }


        /// <summary>
        /// 获取该用户的所有的权限列表
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseMessage<List<string>>> JurisdictionList(string useId)
        {
            var response = new ResponseMessage<List<string>>();
            try
            {          
                var UserRole = from b in _IRolesStore.GetUserRoleAsync().Where(p => p.UserId == useId)
                               join c in _IRolesStore.GetRolePermissionsAsync()
                               on b.RoleId equals c.RoledId into b1
                               from c1 in b1.DefaultIfEmpty()
                               select c1;
                response.Extension = await UserRole.Select(p => p.PermissionsId).Distinct().ToListAsync();
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;

        }


    }
}
