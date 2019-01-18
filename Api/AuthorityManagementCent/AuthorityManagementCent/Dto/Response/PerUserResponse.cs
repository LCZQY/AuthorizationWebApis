using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Response
{
    /// <summary>
    /// 组合组织树状结构
    /// </summary>
    public class PerUserResponse
    {

        /// <summary>
        /// 当前登陆用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public List<string> PermissionList { get; set; }


    }

}
