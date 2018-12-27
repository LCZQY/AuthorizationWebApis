using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;
using AuthorityManagementCent.Stores.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuthorityManagementCent.Stores
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class TokenStore : ITokenStore
    {
        private readonly ModelContext dbContext;

        public TokenStore(ModelContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 判断该用户名是否存在
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Users> IExiexistence(LoginRequest users)
        {  
            return await dbContext.Users.Where(u => u.UserName == users.userName && !u.IsDeleted).FirstOrDefaultAsync();
        }
    }
}
