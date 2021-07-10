using AuthorityManagementCent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> DeleteUser(List<string> userId);

        /// <summary>
        /// 添加用户       
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        Task<Users> InsertUser(Users organizations);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        Task<Users> EditUser(Users userInfo);

        /// <summary>
        /// 待条件用户信息搜索
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<TResult> GetUserAsync<TResult>(Func<IQueryable<Users>, IQueryable<TResult>> query, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 用户是否存在
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> isExist(string userId);

    }
}
