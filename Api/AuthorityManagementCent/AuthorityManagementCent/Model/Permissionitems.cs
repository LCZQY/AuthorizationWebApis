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
    public class Permissionitems
    {
        /// <summary>
        /// 权限编号Key
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 权限分组
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
