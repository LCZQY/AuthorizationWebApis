using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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


        /// <summary>
        /// 添加用户角色表
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<bool> InsertUserRole(List<UserRole> role)
        {

            if (role == null)
            {
                throw new Exception("请求体不能为空");
            }
            await dbContext.UserRoles.AddRangeAsync(role);
            return await dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 查询用户角色信息
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TResult> GetUserRoleAsync<TResult>(Func<IQueryable<UserRole>, IQueryable<TResult>> query, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.Invoke(dbContext.UserRoles).SingleOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// 查询角色信息
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TResult> GetRoleAsync<TResult>(Func<IQueryable<Roles>, IQueryable<TResult>> query, CancellationToken cancellationToken = default(CancellationToken))
        {

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.Invoke(dbContext.Roles).SingleOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// 用户-角色表
        /// </summary>
        /// <returns></returns>
        public IQueryable<UserRole> GetUserRoleAsync()
        {
            return dbContext.UserRoles.AsNoTracking();
        }

        /// <summary>
        /// 角色表
        /// </summary>
        /// <returns></returns>
        public IQueryable<Roles> GetRoleAsync()
        {
            return dbContext.Roles.AsNoTracking();
        }
        /// <summary>
        /// 角色-权限表
        /// </summary>
        /// <returns></returns>
        public IQueryable<RolePermissions> GetRolePermissionsAsync()
        {
            return dbContext.RolePermissions.AsNoTracking();
        }

        /// <summary>
        /// 添加权限扩展表
        /// </summary>
        /// <param name="permissionsEX"></param>
        /// <returns></returns>
        public async Task<bool> InsertRolePermissionEX(List<PermissionExpansion> permissionsEX)
        {
            if (permissionsEX == null)
            {
                throw new Exception("请求体不能为空");
            }
            await dbContext.PermissionExpansions.AddRangeAsync(permissionsEX);
            return await dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 权限扩展表
        /// </summary>
        /// <returns></returns>
        public IQueryable<PermissionExpansion> PermissionExpansions()
        {
            return dbContext.PermissionExpansions.AsNoTracking();
        }

        /// <summary>
        /// 返回所有对应权限的组织范围
        /// </summary>
        /// <param name="UerId"></param>
        /// <param name="PermissionId"></param>
        /// <returns></returns>
        public async Task<PermissionsScope> BrowsingScope(string UerId, string PermissionId)
        {
            var query = await (dbContext.PermissionExpansions.Where(p => p.UserId.Equals(UerId) && p.PermissionId.Equals(PermissionId)).GroupBy(o => o.PermissionId).Select(
                y => new PermissionsScope
                {
                    PermissionsId = y.Key,
                    OrganizationScope = y.Select(i => i.OrganizationId).ToList()
                })).SingleOrDefaultAsync();
            //query.ForEach(o => o.OrganizationScope = o.OrganizationScope.Distinct().ToList());
             query.OrganizationScope = query.OrganizationScope.Distinct().ToList();
            return query;
        }

        /// <summary>
        /// 该用户的所有权限Id集合
        /// </summary>
        /// <param name="UerId"></param>
        /// <returns></returns>
        public async  Task<bool> ReturnAuthorityName(string UerId, string PermissionId)
        {
            //用户角色
            var UserRole =await dbContext.PermissionExpansions.Where(p => p.UserId.Equals(UerId) && p.PermissionId.Contains(PermissionId)).ToListAsync();
            var df = UserRole.Count() == 0 ? false : true; 
            return UserRole.Count() == 0 ? false : true;
        }
    }
}

