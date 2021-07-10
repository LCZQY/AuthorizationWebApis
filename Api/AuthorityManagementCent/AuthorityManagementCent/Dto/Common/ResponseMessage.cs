using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AuthorityManagementCent.Dto.Common
{
    /// <summary>
    /// 返回实体
    /// </summary>
    public class ResponseMessage
    {
        public string Code
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            set;
        }

        public string Message
        {
            [CompilerGenerated]
            get;
            [CompilerGenerated]
            set;
        }

        public ResponseMessage()
        {
            Code = ResponseCodeDefines.SuccessCode;
        }

        public bool IsSuccess()
        {
            if (Code == ResponseCodeDefines.SuccessCode)
            {
                return true;
            }
            return false;
        }
    }

    public class ResponseMessage<TEx> : ResponseMessage
    {
        public TEx Extension { get; set; }
    }

    public class PagingResponseMessage<Tentity> : ResponseMessage<List<Tentity>>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public long TotalCount { get; set; }
    }
}
