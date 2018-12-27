using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Request
{
    public class LoginRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(6,ErrorMessage ="最多输入6位数")]
        public string userName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string passWord { get; set; }
    }
}
