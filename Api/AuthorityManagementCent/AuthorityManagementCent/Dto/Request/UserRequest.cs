namespace AuthorityManagementCent.Dto.Request
{
    public class UserRequest
    {
        /// <summary>
        ///主键
        /// </summary>
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
        /// 号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 初始密码
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex { get; set; }
    }
}
