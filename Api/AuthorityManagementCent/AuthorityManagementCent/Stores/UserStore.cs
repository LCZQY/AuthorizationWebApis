using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        /// 获取用户信息（带条件）
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TResult> GetUserAsync<TResult>(Func<IQueryable<Users>, IQueryable<TResult>> query, CancellationToken cancellationToken = default(CancellationToken))
        {

            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return query.Invoke(dbContext.Users).SingleOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<Users> InsertUser(Users users)
        {
            if (users == null)
            {
                throw new Exception(nameof(users));
            }
            await dbContext.Users.AddAsync(users);
            await dbContext.SaveChangesAsync();
            return users;
        }


        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<Users> GetUserInformation()
        {
            return dbContext.Users.AsNoTracking();
        }

        /// <summary>
        ///  判断该用户是否存在
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> isExist(string userId)
        {
            return await dbContext.Users.AsNoTracking().Where(p => p.Id.Equals(userId)).CountAsync() > 0?true: false;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public async Task<Users> EditUser(Users userInfo)
        {
            if (userInfo == null)
            {
                throw new Exception(nameof(userInfo));
            }
            dbContext.Attach(userInfo);
            dbContext.Update(userInfo);
            await dbContext.SaveChangesAsync();
            return userInfo;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteUser(List<string> userId)
        {
            var quey = dbContext.Users.Where(i => userId.Contains(i.Id)).ToList();
            quey.ForEach(i => i.IsDeleted = true);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
