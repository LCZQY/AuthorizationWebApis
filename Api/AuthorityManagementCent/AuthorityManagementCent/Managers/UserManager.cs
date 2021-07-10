
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Dto.Response;
using AuthorityManagementCent.Model;
using AuthorityManagementCent.Stores.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Managers
{

    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserManager
    {
        private readonly IUserStore _IUserStore;
        private readonly IRolesStore _RolesStore;
        private readonly IMapper _Mapper;

        public UserManager(IUserStore IUserStore, IMapper IMapper, IRolesStore RolesStore)
        {
            this._IUserStore = IUserStore;
            this._Mapper = IMapper;
            this._RolesStore = RolesStore;
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>               
        public virtual async Task<PagingResponseMessage<UsersResponse>> GettingUsers(OranizationUserRequest condition)
        {
            var users = DataBaseUser.TokenModel;
            var pagingResponse = new PagingResponseMessage<UsersResponse>();

            ////判断该用户的权限，锁定该组织范围                 
            //1.1.找到该用户的所有权限
            var scopeList = await _RolesStore.BrowsingScope(users.Id, "User_Add_Edit");
            if (scopeList == null)
            {
                pagingResponse.Message = "暂无权限，请联系管理";
                pagingResponse.Code = ResponseCodeDefines.NotAllow;
                return pagingResponse;
            }

            //1.2.对应权限的所有的可以浏览的范围(默认包含可查看本组织的内容)          
            scopeList.Add(users.OrganizationId);
            var query = _IUserStore.GetUserInformation().Where(p => scopeList.Contains(p.OrganizationId));
            if (condition.OranizationId != null)
            {
                query = _IUserStore.GetUserInformation().Where(u => u.OrganizationId == condition.OranizationId && !u.IsDeleted);
            }
            //员工管理筛选条件【角色】
            if (condition.RoleId != null)
            {
                query = from c in query
                        join b in _RolesStore.GetUserRoleAsync() on
                        c.Id equals b.UserId into c1
                        from c2 in c1.DefaultIfEmpty()
                        where c2.RoleId.Equals(condition.RoleId)
                        select c;
            }

            //员工管理筛选条件【姓名】
            if (condition.TrueName != null)
            {
                query = query.Where(p => p.TrueName.Contains(condition.TrueName));
            }

            //员工管理筛选条件【部门】
            if (condition.EpartmentId != null)
            {
                query = query.Where(p => p.OrganizationId.Equals(condition.EpartmentId));
            }

            //员工管理筛选条件【离职】
            if (condition.IsDelete != null)
            {
                query = query.Where(p => p.IsDeleted.Equals(condition.IsDelete));
            }

            pagingResponse.TotalCount = await query.CountAsync();
            var qlist = await query.Skip(condition.PageIndex * condition.PageSize).Take(condition.PageSize).ToListAsync();
            pagingResponse.PageIndex = condition.PageIndex;
            pagingResponse.PageSize = condition.PageSize;
            pagingResponse.Extension = _Mapper.Map<List<UsersResponse>>(qlist);
            return pagingResponse;
        }


        /// <summary>
        /// 添加/编辑员工
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public virtual async Task<ResponseMessage> InsertUserInfo(UserRequest users)
        {
            var user = DataBaseUser.TokenModel;
            var response = new ResponseMessage();
            if (users == null)
            {
                throw new Exception(nameof(users));
            }

            if (await _RolesStore.BrowsingScope(user.Id, "User_Add_Edit") == null)
            {
                response.Message = "暂无权限，请联系管理";
                response.Code = ResponseCodeDefines.NotAllow;
                return response;
            }
            try
            {
                var newUsers = _Mapper.Map<Users>(users);
                if (await _IUserStore.isExist(users.Id))
                {
                    var oldUsers = await _IUserStore.GetUserAsync(p => p.Where(o => o.Id.Equals(users.Id)));
                    oldUsers.PhoneNumber = newUsers.PhoneNumber;
                    oldUsers.TrueName = newUsers.TrueName;
                    oldUsers.UserName = newUsers.UserName;
                    oldUsers.OrganizationId = newUsers.OrganizationId;
                    oldUsers.Sex = newUsers.Sex;
                    await _IUserStore.EditUser(oldUsers);
                    return response;
                }
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
                throw new Exception(el.Message);
            }
            return response;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="usersId"></param>
        /// <returns></returns>
        public virtual async Task<ResponseMessage> DeleteUser(List<string> usersId)
        {
            var user = DataBaseUser.TokenModel;
            var response = new ResponseMessage();
            if (usersId == null)
            {
                throw new Exception(nameof(usersId));
            }
            if (await _RolesStore.BrowsingScope(user.Id, "User_Delete") == null)
            {
                response.Message = "暂无权限，请联系管理";
                response.Code = ResponseCodeDefines.NotAllow;
                return response;
            }
            try
            {
                await _IUserStore.DeleteUser(usersId);
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }
    }
}
