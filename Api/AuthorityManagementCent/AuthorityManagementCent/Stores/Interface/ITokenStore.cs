using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;
using System.Linq;
using System.Threading.Tasks;

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

        IQueryable<Users> GetUsers();




    }
}
