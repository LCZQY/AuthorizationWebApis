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
        /// 权限项集合
        /// </summary>
        public List<PermissionsScope> PermissionsScopes { get; set; }

    }

    public class PermissionsScope
    {

        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermissionsId { get; set; }

        /// <summary>
        /// 该权限ID的组织范围集合
        /// </summary>
        public List<string> OrganizationScope { get; set; }
    }
}
