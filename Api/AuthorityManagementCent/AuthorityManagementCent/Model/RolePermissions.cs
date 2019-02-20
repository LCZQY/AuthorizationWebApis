using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Model
{

    /// <summary>
    /// 角色-权限-范围表
    /// </summary>
    public class RolePermissions
    {
        /// <summary>
        /// Key
        /// </summary>       
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoledId { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermissionsId { get; set; }

        /// <summary>
        /// 组织范围
        /// </summary>
        public string OrganizationScope { get; set; }
    }
}
