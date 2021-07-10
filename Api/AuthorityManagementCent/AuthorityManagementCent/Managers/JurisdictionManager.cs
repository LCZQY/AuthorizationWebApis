using AuthorityManagementCent.Dto.Common;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Dto.Response;
using AuthorityManagementCent.Model;
using AuthorityManagementCent.Stores.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AuthorityManagementCent.Managers
{

    /// <summary>
    /// 权限管理
    /// </summary>
    public class JurisdictionManager
    {
        private readonly IJurisdictionStore _IJurisdictionStore;
        private readonly IMapper _Mapper;

        public JurisdictionManager(IJurisdictionStore iJurisdictionStore, IMapper IMapper)
        {
            this._IJurisdictionStore = iJurisdictionStore;
            this._Mapper = IMapper;
        }




        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>       
        public async Task<ResponseMessage> DeletePermissitem(List<string> id)
        {
            var response = new ResponseMessage();
            if (id == null)
            {
                throw new Exception("被删除的ID不能为空！");
            }
            try
            {
                await _IJurisdictionStore.DeletePermissions(id);
            }
            catch (Exception el)
            {
                throw new Exception(nameof(el.Message));
            }
            return response;

        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permissionitems"></param>
        /// <returns></returns>        
        public virtual async Task<ResponseMessage> InsertJurisdiction(PermissionitemRequest permissionitems)
        {
            var response = new ResponseMessage();
            if (permissionitems == null)
            {
                throw new Exception(nameof(permissionitems));
            }
            try
            {
                var newPermissionitems = _Mapper.Map<Permissionitems>(permissionitems);
                if (await _IJurisdictionStore.isExist(permissionitems.Id))
                {
                    newPermissionitems.Groups = newPermissionitems.Groups;
                    newPermissionitems.Name = newPermissionitems.Name;
                    await _IJurisdictionStore.UpdateJurisdiction(newPermissionitems);
                    return response;
                }
                newPermissionitems.Id = newPermissionitems.Id;
                newPermissionitems.Groups = newPermissionitems.Groups;
                newPermissionitems.Name = newPermissionitems.Name;
                await _IJurisdictionStore.InsertJurisdiction(newPermissionitems);
            }
            catch (Exception el)
            {
                throw new Exception(nameof(el.Message));
            }
            return response;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<List<PermissionResponse>>> ListPermissions(SearchPermissiontemRequest condition)
        {
            try
            {
                var pagingResponse = new PagingResponseMessage<PermissionResponse>();
                var query = _IJurisdictionStore.GettingPermissionitems();
                if (condition.Groups != null)
                {
                    query = query.Where(u => u.Groups == condition.Groups);
                }
                pagingResponse.TotalCount = await query.CountAsync();
                var qlist = await query.Skip(condition.PageIndex * condition.PageSize).Take(condition.PageSize).ToListAsync();
                pagingResponse.PageIndex = condition.PageIndex;
                pagingResponse.PageSize = condition.PageSize;
                pagingResponse.Extension = _Mapper.Map<List<PermissionResponse>>(qlist);
                return pagingResponse;
            }
            catch (Exception el)
            {
                throw new Exception(nameof(el.Message));
            }
        }



        /// <summary>
        /// 查询分组后得权限项
        /// </summary>       
        /// <returns></returns>
        public async Task<ResponseMessage<List<GroupByPermissionResponse>>> ListGroupPermissions()
        {
            var Response = new ResponseMessage<List<GroupByPermissionResponse>>();
            try
            {
                var query = _IJurisdictionStore.GettingPermissionitems().GroupBy(p => p.Groups).Select(p => new GroupByPermissionResponse
                {
                    Groups = p.Key,
                    permissionResponses = p.Select(o => new PermissionResponse
                    {
                        Name = o.Name,
                        Id = o.Id,
                        Groups = o.Groups
                    }).ToList()
                });
                Response.Extension = await query.ToListAsync();
            }
            catch (Exception el)
            {
                throw new Exception(nameof(el.Message));
            }
            return Response;
        }


    }
}
