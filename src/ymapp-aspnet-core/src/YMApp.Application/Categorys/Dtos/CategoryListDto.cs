using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace YMApp.Categorys.Dtos
{
    public class CategoryListDto : EntityDto<long>, IHasCreationTime
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// 上级分类Id
        /// </summary>
        /// <value>The parent identifier.</value>
        public long ParentId { get; set; }
        /// <summary>
        /// 分类级别
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }
        /// <summary>
        /// 分类类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        /// <value>The sort.</value>
        public int Sort { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
