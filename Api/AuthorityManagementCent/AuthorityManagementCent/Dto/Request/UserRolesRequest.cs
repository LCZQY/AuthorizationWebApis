using System.Collections.Generic;

namespace AuthorityManagementCent.Dto.Request
{
    public class UserRolesRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>          
        public List<string> RoleId { get; set; }

    }
}
