using System.ComponentModel.DataAnnotations;

namespace AuthorityManagementCent.Model
{
    /// <summary>
    /// 权限扩展表    
    /// </summary>
    public class PermissionExpansion
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public string PermissionId { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionName { get; set; }


    }
}
