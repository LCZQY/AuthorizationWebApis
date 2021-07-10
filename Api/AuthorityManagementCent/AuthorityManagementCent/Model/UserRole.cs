using System.ComponentModel.DataAnnotations;

namespace AuthorityManagementCent.Model
{
    /// <summary>
    ///用户角色表
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [MaxLength(127)]
        public string UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>        
        [MaxLength(127)]
        public string RoleId { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDeleted { get; set; }

    }
}
