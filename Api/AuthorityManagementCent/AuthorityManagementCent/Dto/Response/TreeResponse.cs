using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Response
{
    /// <summary>
    /// 组合组织树状结构
    /// </summary>
    public class TreeResponse
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

    /// <summary>
    /// 组合组织选择树状结构
    /// </summary>
    public class TreeSelectResponse : TreeResponse
    {
        /// <summary>
        /// 组织Id
        /// </summary>
        public string value { get; set; }

     
    }
}
