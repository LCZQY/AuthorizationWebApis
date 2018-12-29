using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorityManagementCent.Dto.Common
{
    /// <summary>
    /// Token请求数据
    /// </summary>
    public class TokenModel 
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 真实用户名
        /// </summary>
        public string TrueName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }        
    }

    /// <summary>
    /// 储存登陆信息
    /// </summary>
    public static class DataBaseUser {

        public static TokenModel TokenModel { get; set; }
    }

}
