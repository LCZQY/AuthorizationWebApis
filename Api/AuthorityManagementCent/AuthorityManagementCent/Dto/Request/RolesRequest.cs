namespace AuthorityManagementCent.Dto.Request
{
    public class RolesRequest
    {
        /// <summary>
        /// key
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 组织 ID
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
    }
}
