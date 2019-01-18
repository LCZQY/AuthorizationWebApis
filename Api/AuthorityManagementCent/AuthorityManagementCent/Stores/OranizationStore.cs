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
    public class OranizationStore : IOranizationStore
    {
        private readonly ModelContext dbContext;

        public OranizationStore(ModelContext _dbContext)
        {
            dbContext = _dbContext;
        }

        /// <summary>
        /// 添加组织信息
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        public async Task<Organizations> AddOraniztions(Organizations organizations)
        {
            if (organizations == null)
            {
                throw new ArgumentNullException(nameof(organizations));
            }
            dbContext.Organizations.Add(organizations);
            await dbContext.SaveChangesAsync();
            return organizations;
        }

        /// <summary>
        /// 批量添加组织扩展表
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        public async Task<bool> AddOrganizationExpansions(List<OrganizationExpansions> organizations)
        {
            if (organizations == null)
            {
                throw new ArgumentNullException(nameof(organizations));
            }
            await dbContext.OrganizationExpansions.AddRangeAsync(organizations);
            return await dbContext.SaveChangesAsync() > 0;

        }

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteOrganization(string id)
        {
            var query = await dbContext.Organizations.Where(p => p.Id.Contains(id)).ToListAsync();
            query.ForEach(u => u.IsDeleted = true);
            dbContext.AttachRange(query);
            dbContext.UpdateRange(query);
            return await dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 修改组织表
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        public async Task<bool> EditOrganization(Organizations organizations)
        {
            dbContext.Organizations.Attach(organizations);
            dbContext.Organizations.Update(organizations);
            return await dbContext.SaveChangesAsync() > 0;
        }


        /// <summary>
        /// 修改组织扩展表
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        public async Task<bool> EditOrganizationExpansions(OrganizationExpansions organizations)
        {
            dbContext.OrganizationExpansions.Attach(organizations);
            dbContext.OrganizationExpansions.Update(organizations);
            return await dbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 组织
        /// </summary>
        /// <returns></returns>
        public IQueryable<Organizations> GettingOraniztions()
        {
            return dbContext.Organizations.AsNoTracking().Where(u => !u.IsDeleted);
        }

        /// <summary>
        /// 组织信息
        /// </summary>
        /// <returns></returns>
        public IQueryable<OrganizationExpansions> GettingOrganizationExpansions()
        {
            return dbContext.OrganizationExpansions.AsNoTracking();
        }

    }
}
