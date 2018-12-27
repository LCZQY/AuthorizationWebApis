using AuthorityManagementCent.Dto.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Request
{
    /// <summary>
    /// 添加权限
    /// </summary>
    public class PermissionitemRequest
    {
        /// <summary>
        /// 权限编号Key
        /// </summary>        
        public string Id { get; set; }

        /// <summary>
        /// 权限分明名
        /// </summary>
        public string Groups { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// 条件搜索
    /// </summary>
    public class SearchPermissiontemRequest : PageConditionSearch
    {
        /// <summary>
        /// 权限分明名
        /// </summary>
        public string Groups { get; set; }
    }


}
