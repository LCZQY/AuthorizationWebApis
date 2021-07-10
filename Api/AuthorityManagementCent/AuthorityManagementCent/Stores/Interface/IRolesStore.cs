using AuthorityManagementCent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        /// 删除用户角色表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> DeleteUserRoles(string userId, List<string> roleId);


        /// <summary>
        /// 删除权限扩展表
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        Task<bool> DeletePermissionEx(string userId, List<string> permissionId);

        /// <summary>
        /// 删除角色权限表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<bool> DeleteRolePermission(List<string> roleId);

        /// <summary>
        /// 删除用户角色表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<bool> DeleteUserRole(List<string> roleId);
        /// <summary>
        /// 实体删除权限扩展表
        /// </summary>
        /// <param name="PermissEx"></param>
        /// <returns></returns>
        Task<bool> DeletePermissionEx(List<PermissionExpansion> PermissEx);


        /// <summary>
        /// 添加角色-权限表       
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<bool> InsertRolePermissions(List<RolePermissions> role);



        /// <summary>
        /// 添加权限扩展表       
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
        /// 返回权限的组织范围
        /// </summary>
        /// <param name="UerId"></param>
        /// <returns></returns>
        Task<List<string>> BrowsingScope(string UerId, string PermissionId);




        /// <summary>
        /// 返回角色对应的权限ID集合
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<string>> listUserPermision(string roleId);

        /// <summary>
        /// 用户所有权限
        /// </summary>
        /// <param name="UerId"></param>
        /// <returns></returns>
        Task<bool> ReturnAuthorityName(string UerId, string PermissionId);

        /// <summary>
        ///用户角色表
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TResult> GetUserRoleAsync<TResult>(Func<IQueryable<UserRole>, IQueryable<TResult>> query, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<bool> DeleteRole(List<string> roleId);

        Task<TResult> GetRoleAsync<TResult>(Func<IQueryable<Roles>, IQueryable<TResult>> query, CancellationToken cancellationToken = default(CancellationToken));

        IQueryable<UserRole> GetUserRoleAsync();

        IQueryable<Roles> GetRoleAsync();

        IQueryable<RolePermissions> GetRolePermissionsAsync();

    }
}
