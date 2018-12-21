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
        private readonly IMapper _Mapper;

        public OranizationManager(IOranizationStore IOranizationStore, IMapper IMapper)
        {
            this._IOranizationStore = IOranizationStore;
            this._Mapper = IMapper;
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
                ///如果没有点击树状组件表示直接添加的是最顶级的组织 !! 配合树状组件                
                newOranization.Id = Guid.NewGuid().ToString();
                newOranization.OrganizationName = newOranization.OrganizationName;
                newOranization.Phone = newOranization.Phone;
                newOranization.ParentId = newOranization.ParentId;
                await _IOranizationStore.AddOraniztions(newOranization);
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
        public async Task<ResponseMessage<List<OranizationTreeResponse>>> CreatOranizationTree(string OranizationId)
        {
            var response = new ResponseMessage<List<OranizationTreeResponse>>();
            try
            {
                response.Extension = await _IOranizationStore.GettingOraniztions().AsNoTracking().Where(u => u.ParentId == OranizationId).Select(p => new OranizationTreeResponse
                {
                    title = p.OrganizationName,
                    key = p.Id,
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
