using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Stores.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Filters
{
    /// <summary>
    /// 锁定该用户的权限范围
    /// </summary>
    public class CheckAuthority
    {
        private readonly IJurisdictionStore _IJurisdictionStore;
        private readonly IRolesStore _IRolesStore;
        public CheckAuthority(IRolesStore rolesStore, IJurisdictionStore jurisdictionStore)
        {
            this._IRolesStore = rolesStore;
            this._IJurisdictionStore = jurisdictionStore;
        }

        /// <summary>
        /// 返回所有对应权限的组织范围
        /// </summary>
        /// <param name="UerId"></param>
        /// <returns></returns>
        public async Task<List<PermissionsScope>> BrowsingScope(string UerId)
        {
            var query = await (_IRolesStore.PermissionExpansions().Where(p => p.UserId.Equals(UerId)).GroupBy(o => o.PermissionId).Select(
                y => new PermissionsScope
                {
                    PermissionsId = y.Key,
                    OrganizationScope = y.Select(i => i.OrganizationId).ToList()
                })).ToListAsync();
            query.ForEach(o => o.OrganizationScope = o.OrganizationScope.Distinct().ToList());
            return null;
        }

        /// <summary>
        /// 该用户的所有权限Id集合
        /// </summary>
        /// <param name="UerId"></param>
        /// <returns></returns>
        public async Task<List<string>> ReturnAuthorityName(string UerId)
        {
            //用户角色
            var UserRole = from b in _IRolesStore.GetUserRoleAsync().Where(p => p.UserId == UerId)
                           join c in _IRolesStore.GetRolePermissionsAsync()
                           on b.RoleId equals c.RoledId into b1
                           from c1 in b1.DefaultIfEmpty()
                           select c1;
            return await UserRole.Select(p => p.PermissionsId).Distinct().ToListAsync();
        }
    }
}
