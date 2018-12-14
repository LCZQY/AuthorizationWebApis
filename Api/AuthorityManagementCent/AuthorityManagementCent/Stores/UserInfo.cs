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
    public class UserInfo : IuserInfo
    {
        private readonly ModelContext dbContext;
        public UserInfo(ModelContext _dbContext)
        {
            dbContext = _dbContext;
        }
        /// <summary>
        /// 判断该用户是否存在
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<bool> IExiexistence(UsersRequest users)
        {
            var count =await dbContext.Users.Where(u => u.UserName == users.userName && u.PasswordHash == users.passWord).ToListAsync();
            return count.Count() > 0? true: false;
        }
    }
}
