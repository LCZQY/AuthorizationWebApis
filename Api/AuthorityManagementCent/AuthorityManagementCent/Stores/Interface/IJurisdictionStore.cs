using AuthorityManagementCent.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// 修改权限    
        /// </summary>
        /// <param name="permissionitems"></param>
        /// <returns></returns>
        Task<bool> UpdateJurisdiction(Permissionitems permissionitems);


        /// <summary>
        /// 是否存在该组织
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> isExist(string id);


        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        IQueryable<Permissionitems> GettingPermissionitems();



        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeletePermissions(List<string> id);



    }
}
