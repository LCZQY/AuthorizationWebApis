
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
using System;

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
            var response = new ResponseMessage();
            if (rolesRequest == null)
            {
                throw new Exception(nameof(rolesRequest));
            }
            try
            {
                List<RolePermissions> newModel = new List<RolePermissions>() { };
                foreach (var item in rolesRequest.PermissionsScopes)
                {
                    var scope = item.OrganizationScope;
                    var permissions = item.PermissionsId;
                    for (int q = 0; q < permissions.Count; q++)
                    {
                        for (int i = 0; i < scope.Count; i++)
                        {
                            newModel.Add(new RolePermissions
                            {
                                OrganizationScope = scope[i],
                                PermissionsId = permissions[q],
                                RoledId = rolesRequest.RoledId
                            });
                        }
                    }
                }
                await _IRolesStore.InsertRolePermissions(newModel);
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }

    }
}
