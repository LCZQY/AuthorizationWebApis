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
        public async Task<Organizations> CreateOraniztions(Organizations organizations)
        {
            if (organizations == null)
            {
                throw new ArgumentNullException(nameof(organizations));
            }
            dbContext.Organizations.Add(organizations);
            await dbContext.SaveChangesAsync();
            return organizations;
        }
    }
}
