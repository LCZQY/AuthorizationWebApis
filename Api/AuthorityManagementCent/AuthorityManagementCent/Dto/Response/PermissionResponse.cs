﻿using System.Collections.Generic;

namespace AuthorityManagementCent.Dto.Response
{
    /// <summary>
    /// 组合组织树状结构
    /// </summary>
    public class PermissionResponse
    {
        /// <summary>
        /// 权限编号Key
        /// </summary>        
        public string Id { get; set; }

        /// <summary>
        /// 权限分组
        /// </summary>
        public string Groups { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
    }

    public class GroupByPermissionResponse
    {
        /// <summary>
        /// 权限分组
        /// </summary>
        public string Groups { get; set; }

        public List<PermissionResponse> permissionResponses { get; set; }
    }






}
