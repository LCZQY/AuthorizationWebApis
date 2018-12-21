using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Request
{
    public class OranizationRequest
    {
        /// <summary>
        /// 组织名称
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// 号码
        /// </summary>
        [Phone(ErrorMessage ="请输入正确的手机号码")]
        public string Phone { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public string ParentId { get; set; }
    }
}
