using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Model;
using AuthorityManagementCent.Dto.Response;
using AuthorityManagementCent.Dto.Request;

namespace AuthorityManagementCent
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            //用户
            CreateMap<UsersResponse,Users>();
            CreateMap<Users, UsersResponse>();

            //组织
            CreateMap<OranizationRequest, Organizations>();
            CreateMap<Organizations, OranizationRequest>();

        }       
    }
}
