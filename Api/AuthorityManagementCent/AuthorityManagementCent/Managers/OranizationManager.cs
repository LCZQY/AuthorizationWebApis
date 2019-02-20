using System.Linq;
using System.Threading.Tasks;
using AuthorityManagementCent.Dto.Request;
using AuthorityManagementCent.Stores.Interface;
using AuthorityManagementCent.Dto.Common;
using AutoMapper;
using AuthorityManagementCent.Model;
using System;
using AuthorityManagementCent.Dto.Response;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AuthorityManagementCent.Managers
{
    /// <summary>
    /// 组织管理
    /// </summary>
    public class OranizationManager
    {
        private readonly IOranizationStore _IOranizationStore;
        private readonly IRolesStore _IRolesStore;
        private readonly IUserStore _IUserStore;
        private readonly IMapper _Mapper;

        public OranizationManager(IOranizationStore IOranizationStore, IRolesStore RolesStore, IUserStore IUserStore, IMapper IMapper)
        {
            this._IOranizationStore = IOranizationStore;
            this._IRolesStore = RolesStore;
            this._Mapper = IMapper;
            this._IUserStore = IUserStore;
        }

        /// <summary>
        /// 添加组织信息
        /// </summary>
        /// <param name="oranizationRequest"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> PlusOranization(OranizationRequest oranizationRequest)
        {
            var response = new ResponseMessage();
          
            var newOranization = _Mapper.Map<Organizations>(oranizationRequest);
            try
            {
                //修改
                if (oranizationRequest.id != string.Empty)
                {
                    var oran = await _IOranizationStore.GettingOraniztions().AsNoTracking().Where(u => u.Id.Equals(oranizationRequest.id)).SingleOrDefaultAsync();
                    oran.OrganizationName = newOranization.OrganizationName;
                    oran.Phone = newOranization.Phone;
                    await _IOranizationStore.EditOrganization(oran);
                    return response;
                }

                //添加
                var oranizationid = Guid.NewGuid().ToString();
                newOranization.Id = oranizationid;
                newOranization.OrganizationName = newOranization.OrganizationName;
                newOranization.Phone = newOranization.Phone;
                newOranization.ParentId = newOranization.ParentId;
                newOranization.CreateTime = DateTime.Now;
                await _IOranizationStore.AddOraniztions(newOranization);
                List<OrganizationExpansions> organizationExpansions = new List<OrganizationExpansions>() { };


                //递归找到所有的父级节点信息
                var parentList = await ListPrantOranization(new List<Organizations>(), oranizationRequest.ParentId, oranizationRequest.OrganizationName);             
                foreach (var item in parentList)
                {
                    organizationExpansions.Add(new OrganizationExpansions
                    {
                        OrganizationId = item.Id, // 父节点ID
                        OrganizationName = item.OrganizationName,
                        SonId = oranizationid,  // 子节点ID
                        FullName = item.FullName,
                        SonName = oranizationRequest.OrganizationName,
                        //对比父级ID是否相同，相同则是直属关系
                        IsImmediate = item.Id == oranizationRequest.ParentId 
                    });
                }
                await _IOranizationStore.AddOrganizationExpansions(organizationExpansions);
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }



        private string _fullName;
        /// <summary>
        /// 找到组织(sonId)的所有父级组织
        /// 整体思路： 通过下级向上级拼凑组织全名称
        /// </summary>
        /// <returns></returns>
        public async Task<List<Organizations>> ListPrantOranization(List<Organizations> Parentlist, string sonId, string fullname = "")
        {
            if (sonId == null)
            {
                throw new ArgumentNullException(nameof(sonId));
            }
            var query = await _IOranizationStore.GettingOraniztions().Where(p => p.Id.Equals(sonId)).SingleOrDefaultAsync();
            if (query != null)
            {
                ///组合组织全名称
                if (fullname == "")
                {
                    query.FullName = query.OrganizationName;
                }
                else
                {
                    query.FullName = query.OrganizationName + "-" + fullname;
                    _fullName = query.FullName;
                }
                Parentlist.Add(query);
                await ListPrantOranization(Parentlist, query.ParentId, _fullName);
            }
            return Parentlist;
        }


        /// <summary>
        /// 删除组织信息
        /// </summary>
        /// <param name="oranizationRequest"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> RemoveOranization(string oraId)
        {
            var response = new ResponseMessage();
            try
            {
                var uses=await _IUserStore.GetUserInformation().Where(p=>p.OrganizationId.Contains(oraId)).ToListAsync();
                if (uses.Count() > 0)
                {
                    response.Code = ResponseCodeDefines.ObjectAlreadyExists;
                    response.Message = "该组织下存在用户，不能被删除";
                    return response;
                }

                var sonOran = await _IOranizationStore.GettingOraniztions().Where(p => p.ParentId.Equals(oraId)).ToListAsync();
                if (sonOran.Count() > 0)
                {
                    response.Code = ResponseCodeDefines.ObjectAlreadyExists;
                    response.Message = "该组织下存在下级组织，不能被删除";
                    return response;
                }

                await _IOranizationStore.DeleteOrganization(oraId);
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }


        /// <summary>
        /// 找到组织信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<Organizations>> GetOrgnization(string id)
        {
            var response = new ResponseMessage<Organizations>();
            try
            {
                response.Extension = await _IOranizationStore.GettingOraniztions().AsNoTracking().Where(u => u.Id.Equals(id)).SingleOrDefaultAsync();
            }
            catch (Exception el)
            {
                throw new Exception(nameof(el));
            }
            return response;
        }

        /// <summary>
        /// 创建组织树状结构
        /// </summary>
        /// <param name="OranizationId">OranizationId</param>
        /// <returns></returns>
        public async Task<ResponseMessage<List<TreeResponse>>> CreatOranizationTree(string OranizationId)
        {
            var users = DataBaseUser.TokenModel;
            var response = new ResponseMessage<List<TreeResponse>>();
            try
            {


                //1.1.找到该用户的所有权限
                var scopeList = await _IRolesStore.BrowsingScope(users.Id, "Organization_Add_Edit");
                if (scopeList == null)
                {
                    response.Message = "暂无权限，请联系管理";
                    response.Code = ResponseCodeDefines.NotAllow;
                    return response;
                }

                //1.2.对应权限的所有的可以浏览的范围(默认包含可查看本组织的内容)               
                scopeList.Add(users.OrganizationId);
                //在扩展表中找到其父节点并展示
                var IparentList = _IOranizationStore.GettingOrganizationExpansions().Where(p => p.IsImmediate == true && scopeList.Contains(p.SonId));

                //默认展示顶部【如果没有其操作权限提示即可】
                var query = _IOranizationStore.GettingOraniztions().Where(u => !u.IsDeleted);
                if (OranizationId == "0")
                {
                    var oraniztionList = query.Where(u => u.ParentId == OranizationId).Select(p => new TreeResponse
                    {
                        title = p.OrganizationName,//组织名称
                        key = p.Id, //组织ID

                    }).ToListAsync();
                    response.Extension = await oraniztionList;
                }
                else
                {                    
                    var oraniztionList = IparentList.Where(o => o.OrganizationId == OranizationId).Select(p => new TreeResponse
                    {
                        title = p.SonName,//组织名称
                        key = p.SonId, //组织ID

                    }).ToListAsync();
                    response.Extension = await oraniztionList;
                }
            }
            catch (Exception el)
            {
                throw new Exception(el.Message);
            }
            return response;
        }

        /// <summary>
        /// 创建选择树
        /// </summary>
        /// <param name="OranizationId"></param>
        /// <returns></returns>
        public async Task<ResponseMessage<List<TreeSelectResponse>>> CreatSelectTree(string OranizationId)
        {
            var response = new ResponseMessage<List<TreeSelectResponse>>();
            try
            {
                response.Extension = await _IOranizationStore.GettingOraniztions().AsNoTracking().Where(u => u.ParentId == OranizationId).Select(p => new TreeSelectResponse
                {
                    title = p.OrganizationName,
                    key = p.ParentId,
                    value = p.Id
                }).ToListAsync();
            }
            catch (Exception el)
            {
                throw new Exception(nameof(el));
            }
            return response;
        }

    }
}
