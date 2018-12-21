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

        //添加组织        
         Task<Organizations> CreateOraniztions(Organizations organizations);
    }
}
