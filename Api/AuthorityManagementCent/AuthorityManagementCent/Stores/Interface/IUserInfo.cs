using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
namespace AuthorityManagementCent.Stores.Interface
{
    public interface IuserInfo
    {
        Task<bool> IExiexistence(UsersRequest users); 
    }
}
