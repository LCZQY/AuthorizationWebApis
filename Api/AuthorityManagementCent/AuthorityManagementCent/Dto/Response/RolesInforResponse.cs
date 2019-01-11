using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorityManagementCent.Dto.Response
{
    public class RolesInforResponse
    { /// <summary>
      /// Key
      /// </summary>    
        public string Id { get; set; }

        /// <summary>
        /// 组织 ID
        /// </summary>
        public string OrganizationId { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
    }
}
