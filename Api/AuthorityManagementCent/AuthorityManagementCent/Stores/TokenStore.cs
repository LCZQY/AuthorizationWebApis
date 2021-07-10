using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;
using AuthorityManagementCent.Stores.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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

        public IQueryable<Users> GetUsers()
        {
            return dbContext.Users.AsNoTracking();
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
