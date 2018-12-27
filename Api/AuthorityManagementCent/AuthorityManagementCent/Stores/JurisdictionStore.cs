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

    public class JurisdictionStore : IJurisdictionStore
    {
        private readonly ModelContext dbContext;

        public JurisdictionStore(ModelContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 查询权限数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<Permissionitems> GettingPermissionitems()
        {
            return dbContext.Permissionitems.AsNoTracking().Where(u => !u.IsDeleted);
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permissionitems"></param>
        /// <returns></returns>
        public async Task<Permissionitems> InsertJurisdiction(Permissionitems permissionitems)
        {
            if (permissionitems == null)
            {
                throw new ArgumentNullException(nameof(permissionitems));
            }
            dbContext.Permissionitems.Add(permissionitems);
            await dbContext.SaveChangesAsync();
            return permissionitems;
        }
    }
}
