using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;

namespace AuthorityManagementCent.Stores.Interface
{
    public interface ITokenStore
    {

        /// <summary>
        /// 判断该用户名是否存在
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        Task<Users> IExiexistence(LoginRequest users); 
    }
}
