using AuthorityManagementCent.Dto.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Request
{
    /// <summary>
    /// 添加组织
    /// </summary>
    public class OranizationRequest
    {
        /// <summary>
        /// 组织id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 号码
        /// </summary>
        [Phone(ErrorMessage = "请输入正确的手机号码")]
        public string Phone { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public string ParentId { get; set; }
    }

    /// <summary>
    /// 查询组织下的Id
    /// </summary>
    public class OranizationUserRequest : PageConditionSearch
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        public string OranizationId { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleId { get; set; }


        /// <summary>
        /// 员工状态
        /// </summary>
        public bool? IsDelete { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        public string EpartmentId { get; set; }
    }
}
