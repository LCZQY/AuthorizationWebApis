using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Model
{

    /// <summary>
    /// 权限
    /// </summary>
    public class Permissionitems : TraceUpdateBase
    {
        /// <summary>
        /// Key
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// 权限分明名
        /// </summary>
        public string Groups { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

    }
}
