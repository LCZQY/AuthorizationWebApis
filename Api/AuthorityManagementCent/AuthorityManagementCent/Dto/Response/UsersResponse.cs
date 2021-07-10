using System.ComponentModel.DataAnnotations;

namespace AuthorityManagementCent.Dto.Response
{

    public class UsersResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// 真实用户名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///密码
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>

        public bool IsDeleted { get; set; }

        /// <summary>
        /// 号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }
    }
}
