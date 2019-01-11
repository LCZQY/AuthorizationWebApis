using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;
using AuthorityManagementCent.Stores.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuthorityManagementCent.Stores
{

    public class RolesStore : IRolesStore
    {
        private readonly ModelContext dbContext;

        public RolesStore(ModelContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 获取用户信息列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Roles>> GetRolesList()
        {
            return await dbContext.Roles.Where(u => !u.IsDeleted).ToListAsync();
        }


        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<Roles> InsertRoles(Roles roles)
        {
            if (roles == null)
            {
                throw new Exception("请求体不能为空");
            }

            await dbContext.Roles.AddAsync(roles);
            await dbContext.SaveChangesAsync();
            return roles;
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public async Task<Roles> UpdateRoles(Roles roles)
        {
            if (roles == null)
            {
                throw new Exception("请求体不能为空");
            }
            dbContext.Roles.Attach(roles);
            dbContext.Roles.Update(roles);
            await dbContext.SaveChangesAsync();
            return roles;
        }

        /// <summary>
        /// 角色是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> isExistence(string Id)
        {
            return await dbContext.Roles.Where(u => u.Id == Id && !u.IsDeleted).CountAsync() > 0 ? true : false;
        }

        /// <summary>
        /// 添加角色权限表
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<bool> InsertRolePermissions(List<RolePermissions> role)
        {
            if (role == null)
            {
                throw new Exception("请求体不能为空");
            }            
            await dbContext.RolePermissions.AddRangeAsync(role);
            return await dbContext.SaveChangesAsync() > 0;            
        }
    }
}
