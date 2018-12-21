
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Response;
using AuthorityManagementCent.Stores.Interface;
using AuthorityManagementCent.Dto.Common;
using Microsoft.EntityFrameworkCore;

namespace AuthorityManagementCent.Managers
{

    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserManager
    {
        private readonly IUserStore _IUserStore;
        private readonly IMapper _Mapper;

        public UserManager(IUserStore IUserStore, IMapper IMapper)
        {
            this._IUserStore = IUserStore;
            this._Mapper = IMapper;
        }



        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <returns></returns>               
        public virtual async Task<PagingResponseMessage<UsersResponse>> GettingUsers(PageConditionSearch condition)
        {
            var pagingResponse = new PagingResponseMessage<UsersResponse>();
            var query = _IUserStore.GetUserInformation().Where(u=> !u.IsDeleted);
            pagingResponse.TotalCount =await query.CountAsync();
            var qlist = await query.Skip(condition.PageIndex * condition.PageSize).Take(condition.PageSize).ToListAsync();
            pagingResponse.PageIndex = condition.PageIndex;
            pagingResponse.PageSize = condition.PageSize;
            pagingResponse.Extension = _Mapper.Map<List<UsersResponse>>(qlist);
            return pagingResponse;
        }



    }
}
