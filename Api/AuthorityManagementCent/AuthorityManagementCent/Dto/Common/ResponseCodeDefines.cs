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
        /// 100：
        /// </summary>
        public static readonly string ModelStateInvalid = "100";

        /// <summary>
        /// 101
        /// </summary>
        public static readonly string ArgumentNullError = "101";
        /// <summary>
        /// 102
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
    }
}
