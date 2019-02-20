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
        /// 权限项对应的组织范围
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<List<string>>> GetPermisionScopeList(string permissionId)
        {

            var response = new ResponseMessage<List<string>>();
            if (permissionId == null)
            {
                throw new Exception("请求参数为空");
            }

            try
            {
                response.Extension = await _IRolesStore.GetRolePermissionsAsync().Where(u => u.PermissionsId.Equals(permissionId)).Select(p => p.OrganizationScope).ToListAsync();
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }

        /// <summary>
        /// 角色的所有权限
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<List<string>>> GetRolePermisionList(string roleid)
        {

            var response = new ResponseMessage<List<string>>();
            if (roleid == null)
            {
                throw new Exception("请求参数为空");
            }
            try
            {
                response.Extension = await _IRolesStore.listUserPermision(roleid);
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }


        /// <summary>
        /// 获取用户所有的角色
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<List<string>>> GetUserRolesList(string userid)
        {

            var response = new ResponseMessage<List<string>>();
            if (userid == null)
            {
                throw new Exception("请求参数为空");
            }
            try
            {
                response.Extension = await _IRolesStore.GetUserRoleAsync().Where(o => o.UserId.Equals(userid) && !o.IsDeleted).Select(p => p.RoleId).Distinct().ToListAsync();
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
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
            var users = DataBaseUser.TokenModel;
            var response = new ResponseMessage();
            if (userRolesRequest == null)
            {
                throw new Exception(nameof(userRolesRequest));
            }
            try
            {
                var scopeList = await _IRolesStore.BrowsingScope(users.Id, "Role_Add_Edit");
                if (scopeList == null)
                {
                    response.Message = "暂无权限，请联系管理";
                    response.Code = ResponseCodeDefines.NotAllow;
                    return response;
                }

                ////1.1： 找到所有的角色ID              
                var oldRols = await _IRolesStore.GetUserRoleAsync().Where(u => u.UserId.Equals(userRolesRequest.UserId)).Select(p => p.RoleId).ToListAsync();                         
                //请求的权限个数大于原来的原有权限个数就是新增权限,小于的话就是要删除，
                if (oldRols.Count() > userRolesRequest.RoleId.Count())
                {
                    var deleteRoleId = oldRols.Except(userRolesRequest.RoleId).ToList(); //差集                    
                    //1.1. 删除用户角色表
                    await _IRolesStore.DeleteUserRoles(userRolesRequest.UserId, deleteRoleId);

                    //1.2.删除权限扩展表
                    var permissionList =await _IRolesStore.GetRolePermissionsAsync().Where(p => deleteRoleId.Contains(p.RoledId)).Select(u=>u.PermissionsId).ToListAsync();                   
                    await _IRolesStore.DeletePermissionEx(userRolesRequest.UserId, permissionList);
                }
                //新增
                else
                {
                    var  addRoleId = userRolesRequest.RoleId.Except(oldRols); //差集                    
                    var model = new List<UserRole>();
                    foreach (var roleId in addRoleId)
                    {
                        model.Add(new UserRole { RoleId = roleId, UserId = userRolesRequest.UserId });
                    }

                    ////1.2： 找到所有的角色的权限
                    var permissionList =await _IRolesStore.GetRolePermissionsAsync().Where(p => addRoleId.Contains(p.RoledId)).ToListAsync();
                    if (permissionList.Count() == 0)
                    {
                        response.Message = "该角色的权限项未指定.请先完善";
                        response.Code = ResponseCodeDefines.ArgumentNullError;
                        return response;                        
                    }
                    ////1.3： 构建权限扩展表
                    List<PermissionExpansion> PermissionEx = new List<PermissionExpansion>();                    
                    foreach (var item in permissionList)
                    {
                        PermissionEx.Add(new PermissionExpansion
                        {
                            Id = Guid.NewGuid().ToString(),
                            OrganizationId = item.OrganizationScope,
                            OrganizationName = "",
                            PermissionId = item.PermissionsId,
                            PermissionName = "",
                            UserId = userRolesRequest.UserId,
                            UserName = userRolesRequest.UserName
                        });
                    }
                    await _IRolesStore.InsertUserRole(model);
                    await _IRolesStore.InsertRolePermissionEX(PermissionEx);

                }               
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }




        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> DeletRoleAsync(List<string> RoleId)
        {
            var users = DataBaseUser.TokenModel;
            var response = new ResponseMessage();
            if (RoleId == null)
            {
                throw new Exception("请传入参数");
            }
            try
            {
                var scopeList = await _IRolesStore.BrowsingScope(users.Id, "Role_Delete");
                if (scopeList == null)
                {
                    response.Message = "暂无权限，请联系管理";
                    response.Code = ResponseCodeDefines.NotAllow;
                    return response;
                }
                //1.1.查找该角色是否包含了用户,如果该角色已被用户绑定则是规定该角色不能被删除
                var count = _IRolesStore.GetUserRoleAsync().Where(o => o.RoleId.Equals(RoleId)).Count();
                if (count > 0)
                {
                    response.Code = ResponseCodeDefines.ModelStateInvalid;
                    response.Message = "该角色已被用户绑定，请先解绑.";
                }

                // 1.2.如果该角色没有被用户绑定直接删除角色表,角色权限表【这里并没有强制性的角色进行删除，只是删除的单独的角色】【想要强制性删除角色，得需还对用户角色表和权限扩展表进行操作，由于一个角色拥有多个权限，一个用户又有多个角色，在权限扩展表中 会出现权限交叉部分，我们只是想删除该角色下捆绑下对应的用户所组成的权限扩展信息，即从新组合一次，带到权限扩展表中删除即可】
                await _IRolesStore.DeleteRole(RoleId);
                await _IRolesStore.DeleteRolePermission(RoleId);
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }

    }

}
