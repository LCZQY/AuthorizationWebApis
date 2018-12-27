using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;

namespace AuthorityManagementCent.Stores.Interface
{
    public interface IJurisdictionStore
    {
        /// <summary>
        /// 添加权限    
        /// </summary>
        /// <param name="permissionitems"></param>
        /// <returns></returns>
        Task<Permissionitems> InsertJurisdiction(Permissionitems permissionitems);

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        IQueryable<Permissionitems> GettingPermissionitems();
    }
}
