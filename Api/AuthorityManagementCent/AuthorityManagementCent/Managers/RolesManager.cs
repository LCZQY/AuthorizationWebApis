using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Response;
using AuthorityManagementCent.Stores.Interface;
using AuthorityManagementCent.Dto.Common;
using Microsoft.EntityFrameworkCore;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Model;


namespace AuthorityManagementCent.Managers
{

    /// <summary>
    ///角色管理
    /// </summary>
    public class RolesManager
    {

        private readonly IRolesStore _IRolesStore;
        private readonly IMapper _Mapper;

        public RolesManager(IRolesStore IRolesStore, IMapper IMapper)

        {
            this._IRolesStore = IRolesStore;
            this._Mapper = IMapper;
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        public async Task<ResponseMessage<List<RolesInforResponse>>> InforResponseList()
        {
            var response = new ResponseMessage<List<RolesInforResponse>>();
            var qlist = await _IRolesStore.GetRolesList();
            response.Extension = _Mapper.Map<List<RolesInforResponse>>(qlist);
            return response;
        }

        /// <summary>
        /// 添加/修改角色
        /// </summary>
        /// <param name="rolesRequest"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> AddRoles(RolesRequest rolesRequest)
        {
            var response = new ResponseMessage();
            if (rolesRequest == null)
            {
                throw new Exception(nameof(rolesRequest));
            }
            try
            {
                var newRoles = _Mapper.Map<Roles>(rolesRequest);
                if (await _IRolesStore.isExistence(newRoles.Id))
                {
                    newRoles.OrganizationId = newRoles.OrganizationId;
                    newRoles.Name = newRoles.Name;
                    await _IRolesStore.UpdateRoles(newRoles);
                    return response;
                }
                newRoles.Id = Guid.NewGuid().ToString();
                newRoles.OrganizationId = newRoles.OrganizationId;
                newRoles.Name = newRoles.Name;
                await _IRolesStore.InsertRoles(newRoles);
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }

        /// <summary>
        /// 添加角色权限表
        /// </summary>
        /// <param name="rolesRequest"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> AddRolePermissions(RolePermissionsRequest rolesRequest)
        {
            var users = DataBaseUser.TokenModel;
            var response = new ResponseMessage();
            if (rolesRequest == null)
            {
                throw new Exception(nameof(rolesRequest));
            }
            try
            {
                ///1.1.一个用户对应多个角色该角色拥有多个权限，一个权限又对应不同的组织范围   ???

                List<RolePermissions> newModel = new List<RolePermissions>() { };
                foreach (var item in rolesRequest.PermissionsScopes)
                {
                    var Scope = item.OrganizationScope;
                    //权限范围
                    for (int i = 0; i < Scope.Count; i++)
                    {
                        newModel.Add(new RolePermissions
                        {
                            Id = Guid.NewGuid().ToString(),
                            OrganizationScope = Scope[i],
                            PermissionsId = item.PermissionsId,
                            RoledId = rolesRequest.RoledId
                        });
                    }
                }
                var quers = newModel.ToList();
                await _IRolesStore.InsertRolePermissions(newModel);
                /**
                 * 添加权限扩展表
                 */
                List<PermissionExpansion> listPermissionEx = new List<PermissionExpansion>() { };
                foreach (var item in rolesRequest.PermissionsScopes)
                {
                    var Scope = item.OrganizationScope;
                    //权限范围
                    for (int i = 0; i < Scope.Count; i++)
                    {
                        listPermissionEx.Add(new PermissionExpansion
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserId = users.Id,
                            UserName = users.UserName,
                            PermissionId = item.PermissionsId,
                            OrganizationId = Scope[i]
                        });
                    }
                }
                await _IRolesStore.InsertRolePermissionEX(listPermissionEx);

            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }





        /// <summary>
        /// 添加用户角色表
        /// </summary>
        /// <param name="userRolesRequest"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> AddUserRoles(UserRolesRequest userRolesRequest)
        {
            var response = new ResponseMessage();
            if (userRolesRequest == null)
            {
                throw new Exception(nameof(userRolesRequest));
            }
            try
            {
                //var newModel = _Mapper.Map<UserRole>(userRolesRequest);
                var model = new List<UserRole>();
                foreach (var roleId in userRolesRequest.RoleId)
                {
                    model.Add(new UserRole { RoleId = roleId, UserId = userRolesRequest.UserId });
                }
                await _IRolesStore.InsertUserRole(model);
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;

        }

    }
}
