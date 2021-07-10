namespace AuthorityManagementCent.Model
{
    /// <summary>
    ///   组织权限扩展表
    /// </summary>
    public class OrganizationExpansions
    {
        /// <summary>
        /// 组织Id
        /// </summary       
        public string OrganizationId { get; set; }

        /// <summary>
        /// 子组织ID
        /// </summary>
        public string SonId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 子级组织名称
        /// </summary>
        public string SonName { get; set; }

        /// <summary>
        /// 是否直属下级
        /// </summary>
        public bool IsImmediate { get; set; }

        /// <summary>
        /// 组织全名称
        /// </summary>
        public string FullName { get; set; }

    }
}
