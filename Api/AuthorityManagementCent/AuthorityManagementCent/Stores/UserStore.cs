using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;
using AuthorityManagementCent.Stores.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuthorityManagementCent.Stores
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserStore : IUserStore
    {
        private readonly ModelContext dbContext;

        public UserStore(ModelContext _dbContext)
        {
            dbContext = _dbContext;
        }


        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<Users> GetUserInformation()
        {
            return dbContext.Users.AsNoTracking();
        }
    }
}
