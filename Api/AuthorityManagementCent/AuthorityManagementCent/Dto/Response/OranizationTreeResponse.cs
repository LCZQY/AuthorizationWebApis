using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Response
{
    /// <summary>
    /// 组合组织树状结构
    /// </summary>
    public class OranizationTreeResponse
    {
        /// <summary>
        /// 组织名称
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 组织Id
        /// </summary>
        public string key { get; set; }  
    }
}
