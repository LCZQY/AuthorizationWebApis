using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Stores.Interface;
using AuthorityManagementCent.Dto.Common;
namespace AuthorityManagementCent.Managers
{

    /// <summary>
    /// 登陆信息
    /// </summary>
    public class UserInfoManager
    {
        private readonly IuserInfo _iUserInfo;

        public UserInfoManager(IuserInfo iUserInfo)
        {
            this._iUserInfo = iUserInfo;
        }

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public async Task<bool> Exiexistence(UsersRequest users)
        {
            return await _iUserInfo.IExiexistence(users);
        }

    }
}
