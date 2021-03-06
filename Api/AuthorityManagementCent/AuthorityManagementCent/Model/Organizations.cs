﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorityManagementCent.Model
{

    /// <summary>
    /// 组织表
    /// </summary>
    public class Organizations : TraceUpdateBase
    {

        /// <summary>
        /// 组织Id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 部门号码
        /// </summary>
        [Phone]
        public string Phone { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 全名
        /// </summary>
        [NotMapped]
        public string FullName { get; set; }
    }
}
