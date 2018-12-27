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
            CreateMap<UserRequest, Users>();
            CreateMap<Users,UserRequest>();

            //组织
            CreateMap<OranizationRequest, Organizations>();
            CreateMap<Organizations, OranizationRequest>();

            //权限
            CreateMap<PermissionitemRequest, Permissionitems>();
            CreateMap<Permissionitems, PermissionitemRequest >();

        }       
    }
}
