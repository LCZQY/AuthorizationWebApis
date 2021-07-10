namespace AuthorityManagementCent.Dto.Common
{
    /// <summary>
    /// 分页基础类
    /// </summary>
    public class PageConditionSearch
    {
        /// <summary>
        /// 开始页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 行数
        /// </summary>
        public int PageSize { get; set; }
    }
}
