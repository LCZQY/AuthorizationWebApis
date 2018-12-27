
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
using System;

namespace AuthorityManagementCent.Managers
{

    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserManager
    {
        private readonly IUserStore _IUserStore;
        private readonly IMapper _Mapper;

        public UserManager(IUserStore IUserStore, IMapper IMapper)
        {
            this._IUserStore = IUserStore;
            this._Mapper = IMapper;
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>               
        public virtual async Task<PagingResponseMessage<UsersResponse>> GettingUsers(OranizationUserRequest condition)
        {
            var pagingResponse = new PagingResponseMessage<UsersResponse>();
            var query = _IUserStore.GetUserInformation();
            if (condition.OranizationId != null)
            {
                query = _IUserStore.GetUserInformation().Where(u => u.OrganizationId == condition.OranizationId);
            }
            pagingResponse.TotalCount = await query.CountAsync();
            var qlist = await query.Skip(condition.PageIndex * condition.PageSize).Take(condition.PageSize).ToListAsync();
            pagingResponse.PageIndex = condition.PageIndex;
            pagingResponse.PageSize = condition.PageSize;
            pagingResponse.Extension = _Mapper.Map<List<UsersResponse>>(qlist);
            return pagingResponse;
        }


        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public virtual async Task<ResponseMessage> InsertUserInfo(UserRequest users)
        {
            var response = new ResponseMessage();
            if (users == null)
            {
                throw new Exception(nameof(users));
            }
            try
            {
                var newUsers = _Mapper.Map<Users>(users);
                newUsers.Id = Guid.NewGuid().ToString();
                newUsers.PasswordHash = newUsers.PasswordHash;
                newUsers.CreateTime = DateTime.Now;
                newUsers.PhoneNumber = newUsers.PhoneNumber;
                newUsers.TrueName = newUsers.TrueName;
                newUsers.UserName = newUsers.UserName;
                newUsers.OrganizationId = newUsers.OrganizationId;               
                newUsers.Sex = newUsers.Sex;
                await _IUserStore.InsertUser(newUsers);
            }
            catch (Exception el)
            {
                throw new Exception(nameof(el.Message));
            }
            return response;
        }




    }
}
