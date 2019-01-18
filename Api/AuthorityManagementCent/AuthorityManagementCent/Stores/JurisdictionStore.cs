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
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeletePermissions(List<string> id)
        {
            var query = await dbContext.Permissionitems.AsNoTracking().Where(p => id.Contains(p.Id)).ToListAsync();
            query.ForEach(p => p.IsDeleted = true);
            dbContext.AttachRange(query);
            dbContext.UpdateRange(query);
            return await dbContext.SaveChangesAsync() > 0;
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

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> isExist(string id)
        {
            return await dbContext.Permissionitems.AsNoTracking().Where(p => p.Id.Equals(id)).CountAsync() > 0 ? true : false;
        }


        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permissionitems"></param>
        /// <returns></returns>
        public async Task<bool> UpdateJurisdiction(Permissionitems permissionitems)
        {
            if (permissionitems == null)
            {
                throw new ArgumentNullException(nameof(permissionitems));
            }
            dbContext.Permissionitems.Attach(permissionitems);
            dbContext.Permissionitems.Update(permissionitems);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
