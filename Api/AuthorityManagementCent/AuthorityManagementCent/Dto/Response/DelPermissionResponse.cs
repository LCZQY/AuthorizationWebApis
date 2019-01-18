using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Response
{
    /// <summary>
    /// 组合组织树状结构
    /// </summary>
    public class DeteleResponse
    {

        /// <summary>
        /// 被删除权限集合
        /// </summary>
        public List<string> id { get; set; }

    }
}
