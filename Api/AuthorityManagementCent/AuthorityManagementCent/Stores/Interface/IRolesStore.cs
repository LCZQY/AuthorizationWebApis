using System;
using System.Collections.Generic;
using System.Linq;
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
        Task<bool> InsertRolePermissions(List<RolePermissions>  role);


        /// <summary>
        /// 角色是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> isExistence(string name);


        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        Task<Roles> UpdateRoles(Roles roles);

    }
}
