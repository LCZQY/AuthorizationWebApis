using System.ComponentModel.DataAnnotations;

namespace AuthorityManagementCent.Model
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 组织 ID
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }

    }
}
