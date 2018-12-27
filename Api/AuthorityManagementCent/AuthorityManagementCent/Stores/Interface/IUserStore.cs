using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;

namespace AuthorityManagementCent.Stores.Interface
{
    public interface IUserStore
    {        
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        IQueryable<Users> GetUserInformation();


        /// <summary>
        /// 添加用户       
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        Task<Users> InsertUser(Users organizations);
    }
}
