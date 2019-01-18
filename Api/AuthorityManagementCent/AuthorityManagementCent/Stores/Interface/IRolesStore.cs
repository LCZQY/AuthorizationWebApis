using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;

namespace AuthorityManagementCent.Stores.Interface
{
    public interface IRolesStore
    {
        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        Task<List<Roles>> GetRolesList();

        /// <summary>
        /// 添加角色       
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        Task<Roles> InsertRoles(Roles roles);


        /// <summary>
        /// 添加角色-权限表       
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<bool> InsertRolePermissions(List<RolePermissions> role);



        /// <summary>
        /// 添加角色-权限表       
        /// </summary>
        /// <param name="permissionsEX"></param>
        /// <returns></returns>
        Task<bool> InsertRolePermissionEX(List<PermissionExpansion> permissionsEX);


        /// <summary>
        /// 角色是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> isExistence(string name);


        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        Task<Roles> UpdateRoles(Roles roles);


        /// <summary>
        /// 添加角色-权限表       
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<bool> InsertUserRole(List<UserRole> role);


        /// <summary>
        /// 权限扩展表
        /// </summary>
        /// <returns></returns>
        IQueryable<PermissionExpansion> PermissionExpansions();


        /// <summary>
        ///用户角色表
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TResult> GetUserRoleAsync<TResult>(Func<IQueryable<UserRole>, IQueryable<TResult>> query, CancellationToken cancellationToken = default(CancellationToken));

        Task<TResult> GetRoleAsync<TResult>(Func<IQueryable<Roles>, IQueryable<TResult>> query, CancellationToken cancellationToken = default(CancellationToken));

        IQueryable<UserRole> GetUserRoleAsync();

        IQueryable<Roles> GetRoleAsync();

        IQueryable<RolePermissions> GetRolePermissionsAsync();

        /// <summary>
        /// 返回权限的组织范围
        /// </summary>
        /// <param name="UerId"></param>
        /// <returns></returns>
        Task<PermissionsScope> BrowsingScope(string UerId,string PermissionId);

        /// <summary>
        /// 用户所有权限
        /// </summary>
        /// <param name="UerId"></param>
        /// <returns></returns>
        Task<bool> ReturnAuthorityName(string UerId, string PermissionId);
    }
}
