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
    /// <summary>
    /// AutoMapper配置文件
    /// </summary>
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

            //角色
            CreateMap<RolesRequest, Roles>();
            CreateMap<Roles, RolesRequest>();

            //角色-权限-组织范围表
            CreateMap<RolePermissionsRequest, RolePermissions>();
            CreateMap<RolePermissions, RolePermissionsRequest>();


            //用户角色表
            CreateMap<UserRolesRequest, UserRole>();
            CreateMap<UserRole, UserRolesRequest>();

        }       
    }
}
