using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Common
{
    /// <summary>
    /// 返回状态码
    /// </summary>
    public static class ResponseCodeDefines
    {
        /// <summary>
        /// 0 :成功
        /// </summary>
        public static readonly string SuccessCode = "0";

        /// <summary>
        /// 100：模型验证
        /// </summary>
        public static readonly string ModelStateInvalid = "100";

        /// <summary>
        /// 101
        /// </summary>
        public static readonly string ArgumentNullError = "101";

        /// <summary>
        /// 102: 对象已经存在
        /// </summary>
        public static readonly string ObjectAlreadyExists = "102";

        /// <summary>
        /// 103
        /// </summary>
        public static readonly string PartialFailure = "103";

        /// <summary>
        /// 404-不存在
        /// </summary>
        public static readonly string NotFound = "404";

        /// <summary>
        /// 403
        /// </summary>
        public static readonly string NotAllow = "403";

        /// <summary>
        /// 500-服务器错误 
        /// </summary>
        public static readonly string ServiceError = "500";

        /// <summary>
        /// 默认密码
        /// </summary>
        public static readonly string PasswordHash = "123456";

        /// <summary>
        /// 10001-未登录
        /// </summary>
        public static readonly string ArgumentError = "10001";
    }
}
