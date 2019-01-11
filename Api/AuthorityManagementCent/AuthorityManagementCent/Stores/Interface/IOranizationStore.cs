using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;

namespace AuthorityManagementCent.Stores.Interface
{
    public interface IOranizationStore
    {

        /// <summary>
        /// 添加组织        
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        Task<Organizations> AddOraniztions(Organizations organizations);

        /// <summary>
        /// 获取组织数据
        /// </summary>
        /// <returns></returns>
        IQueryable<Organizations> GettingOraniztions();

        /// <summary>
        /// 获取组织扩展表数据
        /// </summary>
        /// <returns></returns>
        IQueryable<OrganizationExpansions> GettingOrganizationExpansions();

      
        
    }
}
