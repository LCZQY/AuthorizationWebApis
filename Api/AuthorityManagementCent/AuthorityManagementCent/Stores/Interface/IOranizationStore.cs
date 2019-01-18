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
        /// 添加组织扩展表
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        Task<bool> AddOrganizationExpansions(List<OrganizationExpansions> organizations);

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

        /// <summary>
        /// 删除组织
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteOrganization(string id);


        /// <summary>
        /// 编辑组织
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        Task<bool> EditOrganization(Organizations organizations);



        /// <summary>
        /// 编辑组织扩展表
        /// </summary>
        /// <param name="organizations"></param>
        /// <returns></returns>
        Task<bool> EditOrganizationExpansions(OrganizationExpansions organizations);


    }
}
