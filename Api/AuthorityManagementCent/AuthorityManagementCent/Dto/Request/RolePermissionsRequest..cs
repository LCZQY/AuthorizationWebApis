using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Request
{
    /// <summary>
    /// 角色-权限-范围表
    /// </summary>    
    public class RolePermissionsRequest
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoledId { get; set; }

        /// <summary>
        /// 权限对应的组织范围
        /// </summary>
        public List<PermissionsScope> PermissionsScopes { get; set; }

    }

    public class PermissionsScope
    {

        /// <summary>
        /// 权限ID
        /// </summary>
        public List<string> PermissionsId { get; set; }

        /// <summary>
        /// 组织范围
        /// </summary>
        public List<string> OrganizationScope { get; set; }
    }
}
